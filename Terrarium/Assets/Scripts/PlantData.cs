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
    [SerializeField] private string title;
    [SerializeField] private Sprite sprite;
    [SerializeField] private plantState state;
    [Min(1)]
    [SerializeField] private int level;
    [Min(1)]
    [SerializeField] private int oxygenPerSecond;
    
    [Min(0)]
    [SerializeField] private int price;
    [Min(0)]
    [SerializeField] private int upgradePrice;
    [SerializeField] private GameObject prefab;

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
        return title;
    }

    public Sprite GetSprite()
    {
        return sprite;
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
        return prefab;
    }

    void NextLevel()
    {
        level += 1;
        onChangedLevel?.Invoke(level);
    }

    void UpgradeOxygenPerSecond()
    {
        oxygenPerSecond *= 2;
        onChangedOxygen?.Invoke(oxygenPerSecond);
    }

    void UpdateUpgradePrice()
    {
        upgradePrice *= 2;
        onChangedUpgradePrice?.Invoke(upgradePrice);
    }
}