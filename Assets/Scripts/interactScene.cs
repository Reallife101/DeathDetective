using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactScene : Interactable
{
    [SerializeField] string sceneName;
    [SerializeField] string locationName;
    public override void interact()
    {
        StartCoroutine(Waitabit());
    }

    IEnumerator Waitabit()
    {
        GameObject.FindGameObjectWithTag("Journal").GetComponent<JournalManager>().discoverScene(locationName);
        yield return new WaitForSeconds(.5f);
        GameObject.FindGameObjectWithTag("PPX").GetComponent<PPXControls>().lerpToScene(sceneName);
    }
}
