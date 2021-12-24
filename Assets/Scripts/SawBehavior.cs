using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBehavior : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 60 * rotateSpeed);
    }
}
