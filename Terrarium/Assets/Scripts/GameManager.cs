using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;
    private static GameObject plantPrefab;
    private static PlantData plantSelectData;
    private static PlantPreview plantPreview; 
    private static bool isPlant = false;
    private static int coin = 0;
    private static int levelGame = 1;
    private static int experienceCurrent = 0;
    private static int experienceUp = 100;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start() 
    {
        UIManager.instance.UpdateLevelText(levelGame);
        UIManager.instance.UpdateExperienceText(0);
    }

    public static int GetCoin()
    {
        return coin;
    }

    public static void AddCoin(int coin)
    {
        GameManager.coin += coin;
        experienceCurrent += coin;

        if(experienceCurrent >= experienceUp)
        {
            experienceCurrent = 0;
            experienceUp *= 7;
            levelGame++;
            UIManager.instance.UpdateLevelText(levelGame);
        }

        UIManager.instance.UpdateExperienceText((float)experienceCurrent / experienceUp);
        UIManager.instance.UpdateCoinText(GameManager.coin);
    }

    public static void RemoveCoin(int coin)
    {
        GameManager.coin -= coin;
        UIManager.instance.UpdateCoinText(GameManager.coin);
    }

    public static void SetPlant(GameObject plantPrefab, PlantData data, PlantPreview plantPreview)
    {
        isPlant = true;
        GameManager.plantPrefab = plantPrefab;
        GameManager.plantSelectData = data;
        GameManager.plantPreview = plantPreview;
        UIManager.instance.SetPanelSelections(true);
    }

    public void Plantar(GameObject select)
    {
        UIManager.instance.SetPanelSelections(false);

        if(plantPrefab == null || plantSelectData == null)
            return;

        plantPreview.StartUpgrade();
        RemoveCoin(plantSelectData.price);
        Vector2 selectPosition = select.transform.position;
        Destroy(select);
        GameObject plant = Instantiate(plantPrefab, selectPosition, Quaternion.identity);
        plant.GetComponent<Plant>().SetPlantData(plantSelectData);
        plantPrefab = null;
        isPlant = false;
        plantSelectData = null;
        plantPreview = null;
    }
}