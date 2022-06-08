using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class accusationScript : MonoBehaviour
{
    [SerializeField] AudioClip ac;
    [SerializeField] bool isKiller;

    public void accusationMade(float timeToWait)
    {
        playAudio();
        if (isKiller)
        {
            // Do something here to indicate winning.
            GameObject.FindGameObjectWithTag("PPX").GetComponent<PPXControls>().fadeToWhite(timeToWait);
        }
        else
        {
            //If we want do something here to indicate a false accusation.
            GameObject.FindGameObjectWithTag("PPX").GetComponent<PPXControls>().fadeToBlack(timeToWait);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().canMove = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<interact>().canInteract = false;
        GameObject.FindGameObjectWithTag("Journal").SetActive(false);
    }

    private void playAudio()
    {
        AudioSource au = GameObject.FindGameObjectWithTag("audioManager").GetComponent<AudioSource>();
        if (au.isPlaying)
        {
            au.Stop();
        }

        au.clip = ac;

        au.Play();
    }

    
}
