using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    private int collectedCoins;
    public int CollectedCoins
    {
        set { collectedCoins = value; }
        get { return collectedCoins; }
    }
}
