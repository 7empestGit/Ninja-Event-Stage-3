using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayStateUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText, coinTextFinish;
    [SerializeField] private GameObject finishPanel;

    #region Singleton
    public static PlayStateUIManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        UICoinUpdate();    
    }
    public void UICoinUpdate()
    {
        coinText.text = $"{GameManager.instance.CollectedCoins}";
    }

    public void OpenFinishPanel()
    {
        finishPanel.SetActive(true);
        coinTextFinish.text = coinText.text;
        GameManager.instance.UpdateCollectedCoins();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.sceneCount + 1);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MenuState");
    }
}
