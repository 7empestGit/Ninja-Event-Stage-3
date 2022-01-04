using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "Scriptable Objects/CarDataSO", order = 0)]
public class CarDataSO : ScriptableObject
{
    public int CarID;
    public int CarPrice;
    public GameObject CarPrefab;
}