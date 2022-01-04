using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCarSkinHolder : MonoBehaviour
{
    [SerializeField] private GameObject[] carModels;

    #region Singleton
    public static TrafficCarSkinHolder instance;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
    }
    #endregion

    public GameObject ReturnSkin()
    {
        int randomIndex = Random.Range(0, carModels.Length);
        return carModels[randomIndex];
    }
}
