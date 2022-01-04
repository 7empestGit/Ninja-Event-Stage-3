using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUIManager : MonoBehaviour
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private GameObject buyButton;
    [SerializeField] private GameObject selectButton;
    [SerializeField] private Button SwitchRightButton;
    [SerializeField] private Button SwitchLeftButton;
    [SerializeField] private GameObject[] carsArray;
    [SerializeField] private CarDataSO[] carsDataArray;

    void Start()
    {
        UpdateUITexts();
        // Loading current selected car
        DeactivateAllCars();
        SetActiveCar(gameData.SelectedCarID, true);
    }

    #region Button Methods
    public void SwitchLeft()
    {
        SetActiveCar(gameData.SelectedCarID, false);
        gameData.SelectedCarID--;
        SetActiveCar(gameData.SelectedCarID, true);
    }

    public void SwitchRight()
    {
        SetActiveCar(gameData.SelectedCarID, false);
        gameData.SelectedCarID++;
        SetActiveCar(gameData.SelectedCarID, true);
    }

    public void BuyCar()
    {

    }

    public void SelectCar()
    {

    }
    #endregion

    private void UpdateUITexts()
    {
        coinText.text = $"COINS: <color=#F9FF00><size=100>{gameData.CoinAmount}";
        priceText.text = $"{carsDataArray[gameData.SelectedCarID].CarPrice}";
    }

    private void DeactivateAllCars()
    {
        foreach (GameObject car in carsArray)
        {
            car.SetActive(false);
        }
    }
    private void SetActiveCar(int id, bool isActive)
    {
        carsArray[id].SetActive(isActive);
        UpdateSwitchButtons();
        UpdateUITexts();
    }

    private void UpdateSwitchButtons()
    {
        // if the most left one
        if(gameData.SelectedCarID == 0)
        {
            SwitchLeftButton.interactable = false;
        }
        // if the most right one
        else if (gameData.SelectedCarID == carsArray.Length - 1)
        {
            SwitchRightButton.interactable = false;
        }
        else
        {
            SwitchRightButton.interactable = true;
            SwitchLeftButton.interactable = true;
        }
    }
}
