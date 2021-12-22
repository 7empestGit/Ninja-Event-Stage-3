using UnityEngine;

public class TrafficGenerator : MonoBehaviour
{
    [SerializeField] private int amountOfCars;
    [SerializeField] private GameObject carPrefab;

    void Start()
    {
        for(int i = 0; i < amountOfCars; i++)
        {
            Instantiate(carPrefab, gameObject.transform);
        }
    }
}
