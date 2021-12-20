using UnityEngine;

[CreateAssetMenu(fileName = "Plant", menuName = "Terrarium/Plant")]
public class PlantSO : ScriptableObject 
{
    [SerializeField] private plantState state;
    [SerializeField] private string title;
    [SerializeField] private Sprite sprite;
    [SerializeField] private GameObject prefab;
    [Min(1)]
    [SerializeField] private int level = 1;
    [Min(1)]
    [SerializeField] private int oxygenPerSecond = 1;
    [Min(0)]
    [SerializeField] private int price = 0;
    [Min(1)]
    [SerializeField] private int upgradePrice = 1;

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

    public GameObject GetPrefab()
    {
        return prefab;
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
}