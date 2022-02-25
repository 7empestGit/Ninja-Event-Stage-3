using UnityEngine;
using Dreamteck.Splines;

public class SplineGenerator : MonoBehaviour
{
    [SerializeField] private SplineComputer splineComputer;
    [SerializeField] private int splinePointsLength;

    [SerializeField] private GameObject finishLinePrefab;
    [SerializeField] private GameObject[] props;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject doubleCoinPrefab;
    private SplinePoint[] splinePoints;

    void Awake()
    {
        Generate();
    }

    public void Generate()
    {
        splinePointsLength = Random.Range(30, 60);
        splinePoints = new SplinePoint[splinePointsLength];
        float prevZ = 0;
        float time = Random.Range(0, 999999f);
        for (int i = 0; i < splinePoints.Length; i++)
        {
            splinePoints[i].size = 1f;
            splinePoints[i].position.z += prevZ + Random.Range(9f, 13f);
            splinePoints[i].position.y = 10f * Mathf.PerlinNoise(time + 0.02f, 0);
            splinePoints[i].position.x = 100f * Mathf.PerlinNoise(time + 0.01f, 0);
            time += 0.1f;
            prevZ = splinePoints[i].position.z;
        }
        splineComputer.SetPoints(splinePoints, SplineComputer.Space.World);

        // Prop Generation
        GameObject propsParent = new GameObject("PropsParent");
        SplinePoint[] splines = splineComputer.GetPoints();
        for (int i = 5; i < splines.Length; i += 2)
        {
            int isPlus = Random.Range(0, 2) == 0 ? 1 : -1; // randomizing the left/right side of the road
            Vector3 offset = new Vector3(0, 1, Random.Range(3, 6) * isPlus);    // setting the offset
            GameObject propInstance = Instantiate(props[Random.Range(0, props.Length)], splines[i].position + offset, Quaternion.Euler(0, Random.Range(0f, 360f), 0));
            propInstance.transform.parent = propsParent.transform;
            if (Random.Range(0, 2) == 1)
            {
                i++;
                Instantiate(coinPrefab, splines[i].position + new Vector3(0, 1, 0), Quaternion.identity);
            }
            else if (Random.Range(0, 3) == 1)
            {
                i++;
                Instantiate(doubleCoinPrefab, splines[i].position + new Vector3(0, 1, 0), Quaternion.identity);
            }
        }
        // Instatiating finishLine prefab at the end of the spline
        Instantiate(finishLinePrefab, splines[splines.Length - 1].position, Quaternion.Euler(90, 0, 0));
    }
}