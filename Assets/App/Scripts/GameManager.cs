using System.Collections;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameData gameData;
    [SerializeField] private CinemachineVirtualCamera mainCamera;
    [SerializeField] private Transform startPoint;
    [SerializeField] private GameObject[] carsPrefab;

    public bool IsPowerupActive;

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
        // Load data
        gameData = GameDataHandler.LoadState();
        // Instantiating selected car
        GameObject carInstance = Instantiate(carsPrefab[gameData.SelectedVehicleID], startPoint.position, Quaternion.identity);
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
