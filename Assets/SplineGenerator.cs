using UnityEngine;
using Dreamteck.Splines;

public class SplineGenerator : MonoBehaviour
{
    [SerializeField] private SplineComputer splineComputer;
    [SerializeField] private int splinePointsLength;
    private SplinePoint[] splinePoints;
    public void Generate()
    {
        splinePointsLength = Random.Range(30, 60);
        splinePoints = new SplinePoint[splinePointsLength];
        float prevX = 0;
        float time = Random.Range(0, 999999f);
        for (int i = 0; i < splinePoints.Length; i++)
        {
            splinePoints[i].size = 1f;
            splinePoints[i].position.x += prevX + Random.Range(9f, 13f);
            splinePoints[i].position.y = 10f * Mathf.PerlinNoise(time + 0.02f, 0);
            splinePoints[i].position.z = 100f * Mathf.PerlinNoise(time + 0.01f, 0);
            time += 0.1f;
            prevX = splinePoints[i].position.x;
        }
        splineComputer.SetPoints(splinePoints, SplineComputer.Space.World);
    }
}