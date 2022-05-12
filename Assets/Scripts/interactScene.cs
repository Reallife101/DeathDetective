using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interactScene : Interactable
{
    [SerializeField] string sceneName;
    public override void interact()
    {
        SceneManager.LoadScene(sceneName);
    }
}
