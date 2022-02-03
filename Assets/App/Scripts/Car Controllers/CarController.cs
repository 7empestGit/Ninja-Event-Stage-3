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
        //carRigidbody.AddForce(transform.forward * motor);
        float steering = maxSteeringAngle * touchSide;

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
        //slow the velocity by 50%
        carRigidbody.velocity *= 0.5f;
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
}