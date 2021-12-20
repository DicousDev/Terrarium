using System;
using UnityEngine;

public enum plantState { plant, upgrade };

[System.Serializable]
public class PlantData
{
    public Action<int> onChangedLevel;
    public Action<int> onChangedOxygen;
    public Action<int> onChangedUpgradePrice;
    public Action onChangedStateToUpgrade;
    [SerializeField] private PlantSO plantSO;
    [SerializeField] private plantState state;
    [SerializeField] private int level;
    [SerializeField] private int oxygenPerSecond;
    [SerializeField] private int price;
    [SerializeField] private int upgradePrice;

    public void Initialize()
    {
        state = plantSO.GetPlantState();
        level = plantSO.GetLevel();
        oxygenPerSecond = plantSO.GetOxygenPerSecond();
        price = plantSO.GetPrice();
        upgradePrice = plantSO.GetUpgradePrice();

    }

    public void ChangeToUpgrade()
    {
        state = plantState.upgrade;
        onChangedStateToUpgrade?.Invoke();
        onChangedUpgradePrice?.Invoke(upgradePrice);
    }

    public void Upgrade()
    {
        if(state == plantState.plant) return;

        NextLevel();
        UpgradeOxygenPerSecond();
        UpdateUpgradePrice();
    }

    public string GetTitle()
    {
        return plantSO.GetTitle();
    }

    public Sprite GetSprite()
    {
        return plantSO.GetSprite();
    }

    public plantState GetPlantState()
    {
        return state;
    }
    
    public int GetLevel()
    {
        return level;
    }

    public int GetOxygenPerSecond()
    {
        return oxygenPerSecond;
    }

    public int GetPrice()
    {
        return price;
    }

    public int GetUpgradePrice()
    {
        return upgradePrice;
    }

    public GameObject GetPrefab()
    {
        return plantSO.GetPrefab();
    }

    void NextLevel()
    {
        level += 1;
        onChangedLevel?.Invoke(GetLevel());
    }

    void UpgradeOxygenPerSecond()
    {
        oxygenPerSecond *= 2;
        onChangedOxygen?.Invoke(GetOxygenPerSecond());
    }

    void UpdateUpgradePrice()
    {
        upgradePrice *= 2;
        onChangedUpgradePrice?.Invoke(GetUpgradePrice());
    }
}