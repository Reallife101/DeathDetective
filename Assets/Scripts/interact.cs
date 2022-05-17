using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    [SerializeField] float interactDistance;
    [SerializeField] GameObject camera;
    [SerializeField] LayerMask player;

    public bool canInteract = true;

    private Transform oldhit;
    // Start is called before the first frame update
    void Start()
    {
        oldhit = null;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, interactDistance, ~player))
        {
            if (canInteract && hit.transform.GetComponent<Interactable>())
            {
                hit.transform.GetComponent<Interactable>().he.highlighted = true;

                if (oldhit != null && oldhit != hit.transform)
                {
                    oldhit.GetComponent<Interactable>().he.highlighted = false;
                }

                oldhit = hit.transform;

                if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire1"))
                {
                    hit.transform.GetComponent<Interactable>().interact();
                }
            }
            else if (oldhit != null)
            {
                oldhit.GetComponent<Interactable>().he.highlighted = false;
                oldhit = null;
            }
        }

    }

}
