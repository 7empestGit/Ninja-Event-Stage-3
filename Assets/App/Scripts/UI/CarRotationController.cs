using System.Collections;
using UnityEngine;

[SelectionBase]
public class CarRotationController : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("RotateCar", 0.01f, 0.01f);
    }

    private void RotateCar()
    {
        gameObject.transform.Rotate(Vector3.up);
    }
}
