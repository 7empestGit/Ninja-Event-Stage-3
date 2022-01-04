using UnityEngine;

[SelectionBase]
public class CarRotationController : MonoBehaviour
{
    private static Quaternion previousRotation = Quaternion.Euler(0, -270f, -15f);

    void OnEnable()
    {
        transform.rotation = previousRotation;
    }

    void Start()
    {
        InvokeRepeating("RotateCar", 0.01f, 0.01f);
    }

    private void RotateCar()
    {
        gameObject.transform.Rotate(Vector3.up);
    }

    void OnDisable()
    {
        previousRotation = transform.rotation;
    }
}
