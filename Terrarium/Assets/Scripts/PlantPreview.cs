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

    public void Initialize(PlantData plant)
    {
        this.plant = plant;
        SetTitle(plant.title);
        SetLevel(plant.level);
        SetOxygen(plant.oxygenPerSecond);
        SetSprite(plant.sprite);
        plantButton.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        CartManager.instance.CloseCart();
        GameManager.SetPlant(plant.prefab);
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

    void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
