using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updateJournalTooltip : MonoBehaviour
{
    [SerializeField] AudioClip ac;
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    public void playTooltip()
    {
        StartCoroutine(playTooltipC());

        AudioSource au = GetComponent<AudioSource>();
        if (au.isPlaying)
        {
            au.Stop();
        }

        au.clip = ac;

        au.Play();
    }

    IEnumerator playTooltipC()
    {
        text.text = "J ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Jo ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Jou ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Jour ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Journ ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Journa ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Journal ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Journal  ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Journal U ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Journal Up ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Journal Upd ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Journal Upda ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Journal Updat ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Journal Update ";
        yield return new WaitForSeconds(0.1f);
        text.text = "Journal Updated ";
        yield return new WaitForSeconds(2.5f);
        text.text = "";
    }
}
