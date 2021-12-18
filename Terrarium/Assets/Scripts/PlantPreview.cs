using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PlantPreview : MonoBehaviour
{
    [SerializeField] private PlantData plant;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI oxygenText;
    [SerializeField] private Image image;
    [SerializeField] private Button plantButton;
    [SerializeField] private TextMeshProUGUI plantText;

    public void StartUpgrade()
    {
        plant.state = plantState.upgrade;
        SetUpgradePrice(plant.upgradePrice);
    }

    public void Initialize(PlantData plant)
    {
        this.plant = plant;
        SetTitle(plant.title);
        SetLevel(plant.level);
        SetOxygen(plant.oxygenPerSecond);
        SetSprite(plant.sprite);
        plantButton.onClick.AddListener(ButtonClick);

        if(plant.state == plantState.plant)
        {
            plantText.text = plant.price > 0 ? "Plant " + plant.price : "Plant";
        }
        else if(plant.state == plantState.upgrade)
        {
            SetUpgradePrice(plant.upgradePrice);
        }
    }

    void ButtonClick()
    {
        if(plant.state == plantState.plant && GameManager.GetCoin() >= plant.price)
        {
            Plant();
        }
        else if(plant.state == plantState.upgrade)
        {
            Upgrade();
        }
    }

    void Plant()
    {
        CartManager.instance.CloseCart();
        GameManager.SetPlant(plant.prefab, plant, this);
    }

    void Upgrade()
    {
        if(GameManager.GetCoin() < plant.upgradePrice)
            return;
        
        GameManager.RemoveCoin(plant.upgradePrice);
        plant.level += 1;
        plant.upgradePrice *= 2;
        plant.oxygenPerSecond *= 2;
        SetLevel(plant.level);
        SetUpgradePrice(plant.upgradePrice);
        SetOxygen(plant.oxygenPerSecond);
    }

    void SetTitle(string title)
    {
        titleText.text = title;
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

    void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
