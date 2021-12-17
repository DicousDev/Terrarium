using UnityEngine;

[System.Serializable]
public class PlantData
{
    public enum plantState {plant, upgrade, require};
    public string title;
    public Sprite sprite;
    public plantState state;
    public int level;
    public int oxygenPerSecond;
    public GameObject prefab;

    [Header("REQUIRE")]
    public bool requireLevel = false;
    public int levelRequired;
}