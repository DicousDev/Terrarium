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
            return;
        }
           
        Destroy(this.gameObject);
    }

    void OnEnable() 
    {
        GameStart.onGameStart += () => UpdateCoinText(0);
        GameStart.onGameStart += () => SetPanelSelections(false); 
        ScoreManager.onChangedCoin += UpdateCoinText;
        LevelManager.onChangedLevel += UpdateLevelText;
        LevelManager.onChangedExperience += UpdateExperienceText;
    }

    void OnDisable() 
    {
        ScoreManager.onChangedCoin -= UpdateCoinText;
    }

    public void SetPanelSelections(bool value)
    {
        panelSelections.SetActive(value);
    }

    void UpdateLevelText(int level)
    {
        levelText.text = "Level: " + level.ToString();
    }

    void UpdateExperienceText(float percent)
    {
        experience.fillAmount = percent;
    }
    
    void UpdateCoinText(int coin)
    {
        coinText.text = "Coin: " + coin.ToString();
    }
}