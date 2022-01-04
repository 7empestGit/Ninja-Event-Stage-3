using UnityEngine;
using Dreamteck.Splines;

public class TrafficGenerator : MonoBehaviour
{
    [SerializeField] private int amountOfCars;
    [SerializeField] private GameObject carPrefab;

    [SerializeField] private SplineComputer roadSplineComputer;

    void Start()
    {
        double prevDistance = 0.05f;
        for (int i = 0; i < amountOfCars; i++)
        {
            double finalDistance = prevDistance + Random.Range(0.01f, 0.09f);
            GameObject carInstance = Instantiate(carPrefab, transform);
            SplineFollower carInstanceSplineFollower = carInstance.GetComponent<SplineFollower>();
            carInstanceSplineFollower.spline = roadSplineComputer;
            carInstance.name = $"Traffic Car #{i}";

            carInstanceSplineFollower.result.percent = finalDistance;
            prevDistance = finalDistance;
        }
    }

    private void SpawnCarOnRandomPos()
    {

    }
}
