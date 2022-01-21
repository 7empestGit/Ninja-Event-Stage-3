using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera mainCamera;
    [SerializeField] private Transform startPoint;
    [SerializeField] private GameObject[] carsPrefab;


    private int collectedCoins;
    public int CollectedCoins
    {
        set { collectedCoins = value; }
        get { return collectedCoins; }
    }

    #region Singleton
    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        // Instantiating selected car
        GameObject carInstance = Instantiate(carsPrefab[gameData.SelectedCarID], startPoint.position, Quaternion.identity);
        // Setting camera
        mainCamera.Follow = carInstance.transform;
        mainCamera.LookAt = carInstance.transform;
    }

    public void UpdateCollectedCoins()
    {
        gameData.CoinAmount += collectedCoins;
    }
}
