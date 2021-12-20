using System;
using UnityEngine;

public class LevelManager : MonoBehaviour 
{
    private static int levelGame = 1;
    private static int experienceCurrent = 0;
    private static int experienceUp = 100;
    public static Action<int> onChangedLevel;
    public static Action<float> onChangedExperience;

    void OnEnable() 
    {
        GameStart.onGameStart += () => onChangedLevel?.Invoke(levelGame);
        GameStart.onGameStart += () => onChangedExperience?.Invoke(0);
        Plant.onClick += AddExperience;
    }

    public void AddExperience(int experience)
    {
        experienceCurrent += experience;

        if(experienceCurrent >= experienceUp)
        {
            experienceCurrent = 0;
            experienceUp *= 7;
            levelGame++;
            onChangedLevel?.Invoke(levelGame);
        }

        float percent = (float)experienceCurrent / experienceUp;
        onChangedExperience?.Invoke(percent);
    }
}