using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnAround : MonoBehaviour
{
    [SerializeField] Image gray;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LerpOut(1f));
    }

    IEnumerator LerpOut(float lerpDuration)
    {
        float timeElapsed = 0;
        
        gray.color = new Color(150f, 150f, 150f, 1);

        GameObject.FindGameObjectWithTag("Player").transform.Rotate(Vector3.up * 180f);

        while (timeElapsed < lerpDuration)
        {
            gray.color = new Color(150f, 150f, 150f, Mathf.Lerp(1, 0, timeElapsed / lerpDuration));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        gray.color = new Color(150f, 150f, 150f, 0);


    }
}
