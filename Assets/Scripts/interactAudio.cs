using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactAudio : Interactable
{
    [SerializeField] AudioClip ac;
    [SerializeField] float volume = .8f;

    [SerializeField] string locationName;
    [SerializeField] int clueNumber;
    public override void interact()
    {
        GetComponent<AudioSource>().PlayOneShot(ac, volume);
        GameObject.FindGameObjectWithTag("Journal").GetComponent<JournalManager>().discoverClue(locationName, clueNumber);
    }
}
