 //This code is from: https://answers.unity.com/questions/1580505/make-object-b-visible-when-clicking-on-object-acli.html

using UnityEngine;

public class Raycaster : MonoBehaviour
{
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
                if (Physics.Raycast(ray, out hit, 150.0f))
                {
                    Markup hasMarkup = hit.transform.gameObject.GetComponent<Markup>();
                    if (hasMarkup != null)
                    {
                        hasMarkup.ToggleLinkedObject();
                    }
                }
    }
        }
}
