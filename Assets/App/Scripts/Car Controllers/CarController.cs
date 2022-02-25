using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class CarController : MonoBehaviour
{
    [SerializeField] private List<AxleInfo> axleInfos;
    [SerializeField] private float maxMotorTorque;
    [SerializeField] private float maxSteeringAngle;
    [SerializeField] private Rigidbody carRigidbody;

    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private AudioSource explosionSound;
    [SerializeField] private ParticleSystem smokeParticle;
    [HideInInspector] public int isInvert = 1;
    [HideInInspector] public bool isWon;
    void Start()
    {
        //carRigidbody.velocity = transform.forward * 40f;
        carRigidbody.centerOfMass += new Vector3(0, -1f, 0f);
    }

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        // Limiting speed to 15
        carRigidbody.velocity = Vector3.ClampMagnitude(carRigidbody.velocity, 15f);

        #region Screen Touch
        float touchSide = 0;
        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];
            // left side of the screen
            if (touch.position.x < Screen.width / 2)
            {
                touchSide = -1;
            }
            // right side of the screen
            else if (touch.position.x > Screen.width / 2)
            {
                touchSide = 1;
            }
        }
        else
        {
            touchSide = 0;
        }
        #endregion

        //touchSide = Input.GetAxis("Horizontal");
        float motor = maxMotorTorque;
        float steering = maxSteeringAngle * touchSide * isInvert;

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    public void StopCar()
    {
        //slow the velocity by 10%
        carRigidbody.velocity *= 0.9f;
        maxSteeringAngle = 0;
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = 0;
                axleInfo.rightWheel.motorTorque = 0;

                axleInfo.leftWheel.brakeTorque = maxMotorTorque * 50f;
                axleInfo.rightWheel.brakeTorque = maxMotorTorque * 50f;
            }
        }
        // turn off the script
        enabled = false;
    }

    public void ExplodeCar()
    {
        PlayStateUIManager.Instance.OpenLosePanel();
        carRigidbody.velocity = Vector3.zero;
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = 0;
                axleInfo.rightWheel.motorTorque = 0;

                axleInfo.leftWheel.brakeTorque = maxMotorTorque * 50f;
                axleInfo.rightWheel.brakeTorque = maxMotorTorque * 50f;
            }
        }
        smokeParticle.Play();
        explosionSound.Play();
        explosionParticle.Play();
        enabled = false;
    }
}