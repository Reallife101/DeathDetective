using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class introCutscene : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] string scene;
    [SerializeField] Image white;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Journal").GetComponent<JournalManager>().deleteJ();
        StartCoroutine(Lerp());
    }

    IEnumerator Lerp()
    {
        float timeElapsed = 0;
        camera.transform.localRotation = Quaternion.Euler(14, 0, 0);
        while (timeElapsed < 20f)
        {
            camera.transform.position = new Vector3(Mathf.Lerp(-75f, 5f, timeElapsed / 20f), 4f, 6f);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        camera.transform.position = new Vector3(5f, 4f, 6f);

        timeElapsed = 0;
        camera.transform.localRotation = Quaternion.Euler(54, 180, 0);

        StartCoroutine(Lerp2(0f, 1f, 16f, 2f));

        while (timeElapsed < 18f)
        {
            camera.transform.position = new Vector3(4.3f, 2.7f, Mathf.Lerp(0.5f, -6f, timeElapsed / 20f));
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(scene);

    }

    IEnumerator Lerp2(float start, float end, float wait, float lerpDuration)
    {
        yield return new WaitForSeconds(wait);
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            white.color = new Color(0, 0, 0, Mathf.Lerp(start, end, timeElapsed / lerpDuration));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        white.color = new Color(0, 0, 0, end);

    }
}
