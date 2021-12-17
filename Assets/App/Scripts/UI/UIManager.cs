using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    public void ReturnToMainMenu()
    {
        menuPanel.SetActive(true);
    }
}
