using Dreamteck.Splines;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TrafficCarController : MonoBehaviour
{
    [SerializeField] private GameObject currentCarSkin;
    private SplineFollower splineFollower;

    void Start()
    {
        splineFollower = GetComponent<SplineFollower>();
        OnEndRoadReached();
    }

    public void OnEndRoadReached()
    {
        // Replace current skin
        Destroy(currentCarSkin.gameObject);
        currentCarSkin = Instantiate(TrafficCarSkinHolder.instance.ReturnSkin(), transform);

        // Reset offsets
        splineFollower.offsetModifier.keys.Clear();

        // Randomizing the left/right side spawning position (offset)
        float yOffset = Random.Range(0, 2) == 0 ? 2.025f : -2.025f;
        Vector2 offset = new Vector2(yOffset, 0);
        splineFollower.offsetModifier.AddKey(offset, 0, 1);
        splineFollower.offsetModifier.keys[0].interpolation = AnimationCurve.Constant(0, 1, 1);

        #region Traffic System
        /*        // Randomizing the spawning position
                float roadLength = roadSplineComputer.CalculateLength();
                float randomDistance = Random.Range(0, roadLength);
                splineFollower.SetDistance(randomDistance);

                // Prevent collision with other cars when spawning
                TrafficGenerator trafficGenerator = GetComponentInParent<TrafficGenerator>();

                List<GameObject> carListExceptGameObject = trafficGenerator.carList;
                carListExceptGameObject.Remove(gameObject);

                List<double> trafficCarsDistancesList = new List<double>();
                foreach (GameObject trafficCar in carListExceptGameObject)
                {
                    SplineFollower trafficCarSplineFollower = trafficCar.GetComponent<SplineFollower>();
                    double trafficCarDistance = trafficCarSplineFollower.result.percent * roadLength;
                    trafficCarsDistancesList.Add(trafficCarDistance);
                }
                double[] trafficCarsDistancesArray = trafficCarsDistancesList.ToArray();
                double closestDistance = CSharpMethods.FindClosest(trafficCarsDistancesArray, randomDistance);*/
        #endregion
    }
}
