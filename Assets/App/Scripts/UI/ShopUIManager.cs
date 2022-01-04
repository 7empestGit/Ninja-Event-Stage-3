using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopUIManager : MonoBehaviour
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI buyButtonText;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button switchRightButton;
    [SerializeField] private Button switchLeftButton;
    [SerializeField] private GameObject popupPanel;
    [SerializeField] private GameObject[] carsArray;
    [SerializeField] private CarDataSO[] carsDataArray;

    private int viewingCarID;
    void Start()
    {
        viewingCarID = gameData.SelectedCarID;
        // Loading current selected car
        DeactivateAllCars();
        SetActiveCar(viewingCarID, true);
    }

    #region Button Methods
    public void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
    public void SwitchLeft()
    {
        SetActiveCar(viewingCarID, false);
        viewingCarID--;
        SetActiveCar(viewingCarID, true);
    }

    public void SwitchRight()
    {
        SetActiveCar(viewingCarID, false);
        viewingCarID++;
        SetActiveCar(viewingCarID, true);
    }

    public void BuyCar()
    {
        if (!carsDataArray[viewingCarID].IsBought)
        {
            if (gameData.CoinAmount >= carsDataArray[viewingCarID].CarPrice)
            {
                gameData.CoinAmount -= carsDataArray[viewingCarID].CarPrice;
                carsDataArray[viewingCarID].IsBought = true;
                SelectCar();
            }
            else
            {
                // opens popup window
                popupPanel.SetActive(true);
            }
        }
        else
        {
            SelectCar();
        }
    }
    #endregion

    private void SelectCar()
    {
        carsDataArray[gameData.SelectedCarID].IsSelected = false;
        carsDataArray[viewingCarID].IsSelected = true;
        gameData.SelectedCarID = viewingCarID;
        UpdateBuyButton();
        UpdateUITexts();
    }


    private void UpdateUITexts()
    {
        coinText.text = $"COINS: <color=#F9FF00><size=100>{gameData.CoinAmount}";
        priceText.text = $"{carsDataArray[viewingCarID].CarPrice}";
        priceText.enabled = carsDataArray[viewingCarID].IsBought ? false : true;
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
        UpdateBuyButton();
    }

    private void UpdateSwitchButtons()
    {
        // if the most left one
        if(viewingCarID == 0)
        {
            switchLeftButton.interactable = false;
        }
        // if the most right one
        else if (viewingCarID == carsArray.Length - 1)
        {
            switchRightButton.interactable = false;
        }
        else
        {
            switchRightButton.interactable = true;
            switchLeftButton.interactable = true;
        }
    }
    
    private void UpdateBuyButton()
    {
        if (carsDataArray[viewingCarID].IsBought && carsDataArray[viewingCarID].IsSelected)
        {
            buyButtonText.text = "SELECTED";
            buyButton.interactable = false;
        }
        else if (carsDataArray[viewingCarID].IsBought)
        {
            buyButtonText.text = "SELECT";
            buyButton.interactable = true;
        }
        else
        {
            buyButtonText.text = "BUY";
            buyButton.interactable = true;
        }
    }
}
