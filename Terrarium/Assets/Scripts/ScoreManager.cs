using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour 
{
    private static int coin = 0;
    public static Action<int> onChangedCoin;

    public static void AddCoin(int coin)
    {
        ScoreManager.coin += coin;
        onChangedCoin?.Invoke(ScoreManager.coin);
    }

    public static void RemoveCoin(int coin)
    {
        ScoreManager.coin -= coin;
        onChangedCoin?.Invoke(ScoreManager.coin);
    }

    public static int GetCoin()
    {
        return coin;
    }
}