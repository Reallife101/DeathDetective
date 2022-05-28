using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactAudio : Interactable
{
    [SerializeField] AudioClip ac;
    [SerializeField] float volume = .8f;

    [SerializeField] bool isClue = true;

    [SerializeField] string locationName;
    [SerializeField] int clueNumber;
    public override void interact()
    {
        AudioSource au = GameObject.FindGameObjectWithTag("audioManager").GetComponent<AudioSource>();
        if (au.isPlaying)
        {
            au.Stop();
        }
        
        au.clip = ac;

        au.Play();
        
        if (isClue)
        {
            GameObject.FindGameObjectWithTag("Journal").GetComponent<JournalManager>().discoverClue(locationName, clueNumber);
        }
    }
}
