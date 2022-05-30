using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        } else
        {
            //If we want do something here to indicate a false accusation.
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
