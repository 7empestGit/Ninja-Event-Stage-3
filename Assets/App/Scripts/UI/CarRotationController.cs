using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotationController : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up);
    }
}
