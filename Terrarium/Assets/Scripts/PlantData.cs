using UnityEngine;

public enum plantState {plant, upgrade, require};

[System.Serializable]
public class PlantData
{
    public string title;
    public Sprite sprite;
    public plantState state;
    [Min(1)]
    public int level;
    [Min(1)]
    public int oxygenPerSecond;
    
    [Min(0)]
    public int price;
    [Min(0)]
    public int upgradePrice;
    public GameObject prefab;

    [Header("REQUIRE")]
    public bool requireLevel = false;
    public int levelRequired;
}