using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Toggle musicToggle;

    [SerializeField] private GameData gameData;

    void Start()
    {
        // Load data
        gameData = GameDataHandler.LoadState();
        // apply all the values to the sliders and toggles
        sfxSlider.value = gameData.SFXVolume;
        musicSlider.value = gameData.MusicVolume;
        sfxToggle.isOn = gameData.isSFXMuted;
        musicToggle.isOn = gameData.isMusicMuted;
        // save data
        GameDataHandler.SaveState(gameData);
    }

    public void ReturnToMainMenu()
    {
        menuPanel.SetActive(true);
    }
}
