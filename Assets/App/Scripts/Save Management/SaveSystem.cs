using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private GameData gameData;
    void OnEnable()
    {
        // AutoLoad data on object enables
       gameData = GameDataHandler.LoadState();
    }

    void OnDisable()
    {
        // AutoSave data on object disables
        GameDataHandler.SaveState(gameData);
    }
}
