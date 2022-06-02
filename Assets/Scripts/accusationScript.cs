using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class accusationScript : MonoBehaviour
{
    [SerializeField] AudioClip ac;
    [SerializeField] bool isKiller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void accusationMade()
    {
        playAudio();
        if (isKiller)
        {
            // Do something here to indicate winning.
            GameObject.FindGameObjectWithTag("PPX").GetComponent<PPXControls>().fadeToWhite();
        } else
        {
            //If we want do something here to indicate a false accusation.
            GameObject.FindGameObjectWithTag("PPX").GetComponent<PPXControls>().fadeToBlack();

        }
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
