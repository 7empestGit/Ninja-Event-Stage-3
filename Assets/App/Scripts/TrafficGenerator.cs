using UnityEngine;
using Dreamteck.Splines;
using System.Collections.Generic;

public class TrafficGenerator : MonoBehaviour
{
    [SerializeField] private int amountOfCars;
    [SerializeField] private GameObject carPrefab;

    public List<GameObject> carList;

    void Start()
    {
        for(int i = 0; i < amountOfCars; i++)
        {
            carPrefab.name = $"TrafficCar #{i}";
            Instantiate(carPrefab, transform);
            carList.Add(carPrefab);
        }
    }
}
