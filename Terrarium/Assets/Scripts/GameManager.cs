using UnityEngine;

public class GameManager : MonoBehaviour 
{
    private static GameObject plantPrefab;
    private static PlantData plantSelectData;

    public static void SetPlant(PlantData data)
    {
        GameManager.plantSelectData = data;
        GameManager.plantPrefab = data.GetPrefab();
        UIManager.instance.SetPanelSelections(true);
    }

    public void Plantar(GameObject select)
    {
        UIManager.instance.SetPanelSelections(false);

        if(plantPrefab == null || plantSelectData == null)
            return;

        plantSelectData.ChangeToUpgrade();
        ScoreManager.RemoveCoin(plantSelectData.GetPrice());

        Vector2 selectPosition = select.transform.position;
        GameObject plant = Instantiate(plantPrefab, selectPosition, Quaternion.identity);
        plant.GetComponent<Plant>().SetPlantData(plantSelectData);
        ResetPlant();
    }

    void ResetPlant()
    {
        plantPrefab = null;
        plantSelectData = null;
    }
}