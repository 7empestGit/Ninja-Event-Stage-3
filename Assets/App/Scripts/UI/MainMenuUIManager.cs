using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject levelsPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject quitPanel;

    #region Button methods
    public void PlayGame()
    {
        SceneManager.LoadScene("Level0");
    }

    public void PlayProcedural()
    {
        SceneManager.LoadScene("ProceduralMode");
    }

    public void OpenLevels()
    {
        levelsPanel.SetActive(true);
    }

    public void OpenShop()
    {
        gameObject.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void OpenOptions()
    {
        gameObject.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void OpenCredits()
    {
        gameObject.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void ShowQuit()
    {
        quitPanel.SetActive(true);
    }

    public void HideLevelPanel()
    {
        levelsPanel.SetActive(false);
    }

    public void HideQuit()
    {
        quitPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
