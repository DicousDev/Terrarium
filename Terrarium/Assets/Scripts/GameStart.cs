using System;
using UnityEngine;

public class GameStart : MonoBehaviour 
{
    public static Action onGameStart;

    void Start() 
    {
        onGameStart?.Invoke();
        Destroy(this.gameObject);   
    }
}