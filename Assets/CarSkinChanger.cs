using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class CarSkinChanger : MonoBehaviour
{
    [SerializeField] private GameObject currentCarSkin;


    void Start()
    {
        OnEndRoadReached();
    }

    public void OnEndRoadReached()
    {
        Debug.Log("END ROAD REACHED!");
        Destroy(currentCarSkin.gameObject);
        currentCarSkin = Instantiate(CarSkinHolder.instance.ReturnSkin(), this.transform);
        if (currentCarSkin.gameObject.name != "ambulance")
        {
            GetComponent<SplineFollower>().followSpeed = 50;
        }
    }
}
