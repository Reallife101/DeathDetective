using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactScene : Interactable
{
    [SerializeField] string sceneName;
    public override void interact()
    {
        GameObject.FindGameObjectWithTag("PPX").GetComponent<PPXControls>().lerpToScene(sceneName);

    }
}
