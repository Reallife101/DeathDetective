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
        AudioSource au = GameObject.FindGameObjectWithTag("audioManager").GetComponent<AudioSource>();
        if (au.isPlaying)
        {
            au.Stop();
        }

        au.clip = ac;

        au.Play();
    }
}
