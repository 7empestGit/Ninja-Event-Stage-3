using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem tireSmokeFX;

    [SerializeField] private List<WheelCollider> wheels;

    void FixedUpdate()
    {
        foreach (WheelCollider wheel in wheels)
        {
            WheelHit wheelHit = new WheelHit();
            if (wheel.GetGroundHit(out wheelHit))
            {
                if (wheelHit.sidewaysSlip < 0)
                {
                    wheel.GetComponent<ParticleSystem>().Play();
                }
            }
            print(wheelHit.forwardSlip);
        }
    }
}
