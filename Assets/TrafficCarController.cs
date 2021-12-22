using Dreamteck.Splines;
using UnityEngine;

public class TrafficCarController : MonoBehaviour
{
    [SerializeField] private GameObject currentCarSkin;

    private SplineFollower splineFollower;
    private SplineComputer roadSplineComputer;
    void Start()
    {
        roadSplineComputer = RoadController.instance.GetComponent<SplineComputer>();
        splineFollower = GetComponent<SplineFollower>();
        splineFollower.spline = roadSplineComputer;
        OnEndRoadReached();
    }

    public void OnEndRoadReached()
    {
        // Replace current skin
        Destroy(currentCarSkin.gameObject);
        currentCarSkin = Instantiate(TrafficCarSkinHolder.instance.ReturnSkin(), this.transform);

        // Reset offsets
        splineFollower.offsetModifier.keys.Clear();

        // Randomizing the left/right side spawning position (offset)
        float yOffset = Random.Range(0, 2) == 0 ? 2.025f : -2.025f;
        Vector2 offset = new Vector2(yOffset, 0);
        splineFollower.offsetModifier.AddKey(offset, 0, 1);
        splineFollower.offsetModifier.keys[0].interpolation = AnimationCurve.Constant(0, 1, 1);

        // Randomizing the spawning position
        float roadLength = RoadController.instance.GetComponent<SplineComputer>().CalculateLength();
        float randomDistance = Random.Range(0, roadLength);
        splineFollower.SetDistance(randomDistance);
    }
}
