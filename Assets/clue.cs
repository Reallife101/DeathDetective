using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clue : MonoBehaviour
{
    [SerializeField] AudioClip ac;
    [SerializeField] float volume = .8f;

    [SerializeField] GameObject document;

    public void showDocument()
    {
        document.SetActive(true);
    }

    public void hideDocument()
    {
        document.SetActive(false);
    }

    public void playAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(ac, volume);
    }
}
