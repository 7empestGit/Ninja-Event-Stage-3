using UnityEngine;

public class RoadController : MonoBehaviour
{
    #region Singleton
    public static RoadController instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
}
