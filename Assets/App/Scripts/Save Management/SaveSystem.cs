using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    void Awake()
    {
        // AutoLoad data on the scene begins
        GameDataHandler.LoadState();
    }
}
