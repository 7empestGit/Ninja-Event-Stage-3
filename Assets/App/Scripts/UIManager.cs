using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject quitPanel;


    private void DisableAllPanels()
    {
        GameObject[] panelsArray = { menuPanel, shopPanel, optionsPanel, creditsPanel, quitPanel };
        // Looping through each panel and disable it
        foreach (GameObject panel in panelsArray)
        {
            panel.SetActive(false);
        }
    }


    #region Button methods
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayState");
    }

    public void OpenShop()
    {
        DisableAllPanels();
        shopPanel.SetActive(true);
    }

    public void OpenOptions()
    {
        DisableAllPanels();
        optionsPanel.SetActive(true);
    }

    public void OpenCredits()
    {
        DisableAllPanels();
        creditsPanel.SetActive(true);
    }

    public void ShowQuit()
    {
        DisableAllPanels();
        quitPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
