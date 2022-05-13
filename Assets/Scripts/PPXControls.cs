using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PPXControls : MonoBehaviour
{
    [SerializeField] float lerpDuration = 3f;
    private PostProcessVolume ppv;

    // Start is called before the first frame update
    void Start()
    {
        ppv = GetComponent<PostProcessVolume>();
        StartCoroutine(LerpOut(lerpDuration));
    }

    IEnumerator LerpOut(float lerpDuration)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().enabled = false;
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            ppv.weight = Mathf.Lerp(1, 0, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        ppv.weight = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().enabled = true;
    }

    IEnumerator LerpIn(float lerpDuration, string name)
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            ppv.weight = Mathf.Lerp(0, 1, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        ppv.weight = 1;
        SceneManager.LoadScene(name);
    }

    public void lerpToScene(string name)
    {
        StartCoroutine(LerpIn(lerpDuration/2f, name));
    }
}
