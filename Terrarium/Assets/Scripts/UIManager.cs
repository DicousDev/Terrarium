using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour 
{
    public static UIManager instance;
    [SerializeField] private GameObject panelSelections;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Image experience;

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

        UpdateCoinText(0);
    }

    void Start() 
    {
        SetPanelSelections(false);
    }

    public void UpdateLevelText(int level)
    {
        levelText.text = "Level: " + level.ToString();
    }

    public void UpdateExperienceText(float percent)
    {
        experience.fillAmount = percent;
    }

    public void SetPanelSelections(bool value)
    {
        panelSelections.SetActive(value);
    }
    public void UpdateCoinText(int coin)
    {
        coinText.text = "Coin: " + coin.ToString();
    }
}