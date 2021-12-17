using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Toggle musicToggle;

    [SerializeField] private GameDataSO gameData;

    void Start()
    {
        sfxSlider.value = gameData.SFXVolume;
        musicSlider.value = gameData.MusicVolume;
        sfxToggle.isOn = !gameData.isSFXMuted;
        musicToggle.isOn = !gameData.isMusicMuted;
    }

    public void ReturnToMainMenu()
    {
        menuPanel.SetActive(true);
    }


}
