using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using Dreamteck.Splines;

public class GameManager : MonoBehaviour
{
    private GameData gameData;
    [SerializeField] private CinemachineVirtualCamera mainCamera;
    [SerializeField] private SplineComputer splineComputer;
    [SerializeField] private GameObject[] carsPrefab;
    private Vector3 startPointPosition;
    [HideInInspector] public bool IsPowerupActive;
    public AudioSource coinSound;

    private int collectedCoins;
    public int CollectedCoins
    {
        set { collectedCoins = value; }
        get { return collectedCoins; }
    }

    #region Singleton
    public static GameManager Instance;
    void Awake()
    {
        Instance = this;
    }
    #endregion

    void Start()
    {
        Vector3 normalizedVector = Vector3.zero;
        normalizedVector = splineComputer.GetPoint(1).position.normalized;
        startPointPosition = splineComputer.GetPoint(0).position + new Vector3(0, 5, 2);
        // Load data
        gameData = GameDataHandler.LoadState();
        // Instantiating selected car
        GameObject carInstance = Instantiate(carsPrefab[gameData.SelectedVehicleID], startPointPosition, Quaternion.Euler(normalizedVector));
        // Setting camera
        mainCamera.Follow = carInstance.transform;
        mainCamera.LookAt = carInstance.transform;
    }

    public void UpdateCollectedCoins()
    {
        // Load data
        gameData = GameDataHandler.LoadState();
        // Update coin amount
        gameData.CoinAmount += collectedCoins;
        // Save data
        GameDataHandler.SaveState(gameData);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ActivatePowerup() { IsPowerupActive = true; }
    public void DeactivatePowerup() { IsPowerupActive = false; }
}
