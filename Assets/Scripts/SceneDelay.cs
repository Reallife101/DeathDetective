//Code from this form: https://answers.unity.com/questions/677406/loading-new-scene-after-time.html

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDelay : MonoBehaviour
{
    public float delay = 440;
    public string NewLevel = "";
    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NewLevel);
    }
}
