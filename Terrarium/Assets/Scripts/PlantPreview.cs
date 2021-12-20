using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantPreview : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI oxygenText;
    [SerializeField] private Image image;
    [SerializeField] private Button plantButton;
    [SerializeField] private TextMeshProUGUI plantText;
    [SerializeField] private PlantData plant;
    public static Action onAddPlant;

    public void Initialize(PlantData plant)
    {
        this.plant = plant;
        SubscriberEvents();
        AdjustVariables();
        plantState state = plant.GetPlantState();

        if(state == plantState.plant)
        {
            int price = plant.GetPrice();
            plantText.text = price > 0 ? "Plant " + price : "Plant";
        }
        else if(state == plantState.upgrade)
        {
            int upgradePrice = plant.GetUpgradePrice();
            SetUpgradePrice(upgradePrice);
        }
    }

    void OnEnable() => SubscriberEvents();

    void OnDisable() => UnsubscriberEvents();

    void SubscriberEvents()
    {
        if(plant == null) return;
        
        plant.onChangedLevel += SetLevel;
        plant.onChangedOxygen += SetOxygen;
        plant.onChangedUpgradePrice += SetUpgradePrice;
    }

    void UnsubscriberEvents()
    {
        if(plant == null) return;

        plant.onChangedLevel -= SetLevel;
        plant.onChangedOxygen -= SetOxygen;
        plant.onChangedUpgradePrice -= SetUpgradePrice;
    }

    void AdjustVariables()
    {
        titleText.text = plant.GetTitle();
        SetLevel(plant.GetLevel());
        SetOxygen(plant.GetOxygenPerSecond());
        image.sprite = plant.GetSprite();
        plantButton.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        int coin = ScoreManager.GetCoin();
        plantState state = plant.GetPlantState();

        if(state == plantState.plant && coin >= plant.GetPrice())
        {
            AddPlant();
        }
        else if(state == plantState.upgrade)
        {
            Upgrade();
        }
    }

    void AddPlant()
    {
        onAddPlant?.Invoke();
        GameManager.SetPlant(plant);
    }

    void Upgrade()
    {
        int coin = ScoreManager.GetCoin();
        int price = plant.GetUpgradePrice(); 
        if(coin < price)
            return;
        
        ScoreManager.RemoveCoin(price);
        plant.Upgrade();
    }

    void SetLevel(int level)
    {
        levelText.text = "Level " + level.ToString();
    }

    void SetOxygen(int oxygen)
    {
        oxygenText.text = oxygen.ToString() + " oxygen / s";
    }

    void SetUpgradePrice(int price)
    {
        plantText.text = "upgrade " + price.ToString();
    }
}