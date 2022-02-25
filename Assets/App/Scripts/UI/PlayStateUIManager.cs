using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayStateUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText, coinTextFinish;
    [SerializeField] private GameObject resetButton;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject doubleCoinPowerupSprite;

    #region Singleton
    public static PlayStateUIManager Instance;
    void Awake()
    {
        Instance = this;
    }
    #endregion

    void Start()
    {
        UICoinUpdate();    
    }
    public void UICoinUpdate()
    {
        coinText.text = $"{GameManager.Instance.CollectedCoins}";
    }

    public void OpenFinishPanel()
    {
        resetButton.SetActive(false);
        finishPanel.SetActive(true);
        coinTextFinish.text = coinText.text;
        GameManager.Instance.UpdateCollectedCoins();
    }

    public void OpenLosePanel()
    {
        losePanel.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.sceneCount + 1);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MenuState");
    }

    public void ShowPowerup()
    {
        doubleCoinPowerupSprite.SetActive(true);
    }
}
