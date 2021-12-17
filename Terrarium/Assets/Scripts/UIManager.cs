using UnityEngine;

public class UIManager : MonoBehaviour 
{
    public static UIManager instance;
    [SerializeField] private GameObject panelSelections;

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
        SetPanelSelections(false);
    }

    public void SetPanelSelections(bool value)
    {
        panelSelections.SetActive(value);
    }
}