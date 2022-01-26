using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUIManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI buyButtonText;
    [Header("Buttons")]
    [SerializeField] private Button buyButton;
    [SerializeField] private Button switchRightButton;
    [SerializeField] private Button switchLeftButton;
    [Header("GameObjects")]
    [SerializeField] private GameObject popupPanel;
    [SerializeField] private GameObject[] carsArray;
    [Header("Datas")]
    private GameData gameData;
    private VehicleData[] vehicleDatas;
    private int viewingVehicleID;

    void Start()
    {
        // Load data
        gameData = GameDataHandler.LoadState();
        vehicleDatas = new VehicleData[carsArray.Length];
        VehicleDatasSaveManager("Load");


        // Loading current selected car
        viewingVehicleID = gameData.SelectedVehicleID;
        DeactivateAllCars();
        SetActiveCar(viewingVehicleID, true);
    }

    private void VehicleDatasSaveManager(string operation)
    {
        if (operation == "Save")
        {
            for (int i = 0; i < vehicleDatas.Length; i++)
            {
                VehicleDataHandler.SaveState(vehicleDatas[i], i);
            }
        }
        else if (operation == "Load")
        {
            for (int i = 0; i < vehicleDatas.Length; i++)
            {
                vehicleDatas[i] = VehicleDataHandler.LoadState(i);
            }
        }
        else
        {
            Debug.LogError("Wrong save operation!");
        }
    }

    #region Button Methods
    public void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
    public void SwitchLeft()
    {
        SetActiveCar(viewingVehicleID, false);
        viewingVehicleID--;
        SetActiveCar(viewingVehicleID, true);
    }

    public void SwitchRight()
    {
        SetActiveCar(viewingVehicleID, false);
        viewingVehicleID++;
        SetActiveCar(viewingVehicleID, true);
    }

    public void BuyCar()
    {
        // Load data
        gameData = GameDataHandler.LoadState();
        VehicleDatasSaveManager("Load");

        if (!vehicleDatas[viewingVehicleID].IsBought)
        {
            if (gameData.CoinAmount >= vehicleDatas[viewingVehicleID].VehiclePrice)
            {
                gameData.CoinAmount -= vehicleDatas[viewingVehicleID].VehiclePrice;
                vehicleDatas[viewingVehicleID].IsBought = true;
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
        // Save data
        GameDataHandler.SaveState(gameData);
        VehicleDatasSaveManager("Save");
    }
    #endregion

    private void SelectCar()
    {
        vehicleDatas[gameData.SelectedVehicleID].IsSelected = false;
        vehicleDatas[viewingVehicleID].IsSelected = true;
        gameData.SelectedVehicleID = viewingVehicleID;
        UpdateBuyButton();
        UpdateUITexts();
    }


    private void UpdateUITexts()
    {
        coinText.text = $"COINS: <color=#F9FF00><size=100>{gameData.CoinAmount}";
        priceText.text = $"{vehicleDatas[viewingVehicleID].VehiclePrice}";
        priceText.enabled = vehicleDatas[viewingVehicleID].IsBought ? false : true;
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
        if(viewingVehicleID == 0)
        {
            switchLeftButton.interactable = false;
        }
        // if the most right one
        else if (viewingVehicleID == carsArray.Length - 1)
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
        if (vehicleDatas[viewingVehicleID].IsBought && vehicleDatas[viewingVehicleID].IsSelected)
        {
            buyButtonText.text = "SELECTED";
            buyButton.interactable = false;
        }
        else if (vehicleDatas[viewingVehicleID].IsBought)
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
