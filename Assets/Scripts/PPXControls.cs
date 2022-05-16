using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PPXControls : MonoBehaviour
{
    [SerializeField] PostProcessVolume ppv;
    [SerializeField] PostProcessVolume filmNoir;
    [SerializeField] float lerpDuration = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LerpOut(lerpDuration));
    }

    IEnumerator LerpOut(float lerpDuration)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().canMove = false;
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            ppv.weight = Mathf.Lerp(1, 0, timeElapsed / lerpDuration);
            filmNoir.weight = Mathf.Lerp(0, 1, timeElapsed / (lerpDuration/2));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        ppv.weight = 0;
        filmNoir.weight = 1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().canMove = true;
    }

    IEnumerator LerpIn(float lerpDuration, string name)
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            ppv.weight = Mathf.Lerp(0, 1, timeElapsed / (lerpDuration-.25f));
            filmNoir.weight = Mathf.Lerp(1, 0, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        ppv.weight = 1;
        filmNoir.weight = 0;
        SceneManager.LoadScene(name);
    }

    public void lerpToScene(string name)
    {
        StartCoroutine(LerpIn(lerpDuration/2f, name));
    }
}
