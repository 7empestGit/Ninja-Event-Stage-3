using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    [SerializeField] private Rigidbody carRigidbody;
    [SerializeField] private float forwardVelocity;

    private float horizontalInput;
    private Vector3 m_EulerAngleVelocity;
    [Range(60, 200)]
    [SerializeField] private float degreesPerSec;
    void Start()
    {
        m_EulerAngleVelocity = new Vector3(0, 100, 0);
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        m_EulerAngleVelocity = new Vector3(0, horizontalInput * degreesPerSec, 0);

        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        carRigidbody.MoveRotation(carRigidbody.rotation * deltaRotation);

        carRigidbody.velocity = transform.forward * forwardVelocity;
    }
}
