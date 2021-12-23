using UnityEngine;
using TMPro;
public class PlayStateUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    #region Singleton
    public static PlayStateUIManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    public void UICoinUpdate()
    {
        coinText.text = $"Coins: {GameManager.instance.CollectedCoins}";
    }
}
