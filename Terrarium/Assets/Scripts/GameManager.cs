using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;
    public static GameObject plantPrefab;
    public static bool isPlant = false;

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

    public static void SetPlant(GameObject plantPrefab)
    {
        isPlant = true;
        GameManager.plantPrefab = plantPrefab;
        UIManager.instance.SetPanelSelections(true);
    }

    public void Plantar(GameObject select)
    {
        UIManager.instance.SetPanelSelections(false);

        if(plantPrefab == null) return;

        Vector2 selectPosition = select.transform.position; 
        Destroy(select);
        Instantiate(plantPrefab, selectPosition, Quaternion.identity);
        plantPrefab = null;
        isPlant = false;
    }
}