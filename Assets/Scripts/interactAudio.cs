using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactAudio : Interactable
{
    [SerializeField] AudioClip ac;
    [SerializeField] float volume = .8f;
    public override void interact()
    {
        GetComponent<AudioSource>().PlayOneShot(ac, volume);
    }
}
