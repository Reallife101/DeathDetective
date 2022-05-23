using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenes : MonoBehaviour
{
    [SerializeField] string scene;

    public void loadScene()
    {
        SceneManager.LoadSceneAsync(scene);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
