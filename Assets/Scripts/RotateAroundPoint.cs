using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float rotationSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * rotationSpeed);
        transform.LookAt(target.transform.position);
    }
}
