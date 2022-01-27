using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private VehicleData[] vehicleDatas;

    void OnEnable()
    {
        // AutoLoad data on object enables
        gameData = GameDataHandler.LoadState();
    }

    void OnDisable()
    {
        // AutoSave data on object disables
        gameData = GameDataHandler.LoadState();
        GameDataHandler.SaveState(gameData);
    }
}
