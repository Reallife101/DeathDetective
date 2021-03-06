using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PPXControls : MonoBehaviour
{
    [SerializeField] PostProcessVolume ppv;
    [SerializeField] PostProcessVolume filmNoir;
    [SerializeField] PostProcessVolume fadeWhite;
    [SerializeField] PostProcessVolume fadeBlack;
    [SerializeField] float lerpDuration = 3f;
    [SerializeField] AudioClip audioin;
    [SerializeField] AudioClip audioout;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LerpOut(lerpDuration));
    }

    IEnumerator LerpOut(float lerpDuration)
    {
        GetComponent<AudioSource>().PlayOneShot(audioin, .6f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().canMove = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<interact>().canInteract = false;
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
        GameObject.FindGameObjectWithTag("Player").GetComponent<interact>().canInteract = true;
    }

    IEnumerator LerpIn(float lerpDuration, string name)
    {
        GetComponent<AudioSource>().PlayOneShot(audioout, .6f);
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

    IEnumerator FadeToWhite()
    {
        float timeElapsed = 0;
        while (timeElapsed < 60f)
        {
            fadeWhite.weight = Mathf.Lerp(0, 1, timeElapsed / 60f);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeToBlack()
    {
        float timeElapsed = 0;
        while (timeElapsed < 40f)
        {
            fadeBlack.weight = Mathf.Lerp(0, 1, timeElapsed / 40f);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator WaitToLoadCredits(float timeToWait)
    {
        // wait some time
        Debug.Log("Begin Waiting");
        yield return new WaitForSeconds(timeToWait);
        Debug.Log("Done Waiting");
        SceneManager.LoadScene("EndCredits");
    }
    public void lerpToScene(string name)
    {
        StartCoroutine(LerpIn(lerpDuration/2f, name));
    }

    public void fadeToBlack(float timeToWait)
    {
        StartCoroutine(FadeToBlack());
        StartCoroutine(WaitToLoadCredits(timeToWait));
    }

    public void fadeToWhite(float timeToWait)
    {
        StartCoroutine(FadeToWhite());
        StartCoroutine(WaitToLoadCredits(timeToWait));
    }
}
