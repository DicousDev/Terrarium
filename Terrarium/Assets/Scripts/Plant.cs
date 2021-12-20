using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private PlantData data;
    [SerializeField] private Rigidbody2D rb;
    [Min(0)]
    [SerializeField] private float force = 50;
    [SerializeField] private AddCoinEffect coinEffect;
    public static Action<int> onClick;

    public void SetPlantData(PlantData data)
    {
        this.data = data;
    }

    void Awake() 
    {
        coinEffect = GameObject.Find("AddCoinEffect").GetComponent<AddCoinEffect>();  
    }

    void Start() 
    {
        InvokeRepeating(nameof(AddCoin), 1, 1);
    }

    void AddCoin()
    {
        ScoreManager.AddCoin(data.GetOxygenPerSecond());
    }

    void OnMouseDown() 
    {
        if(data == null) return;
        
        rb.AddForce(Vector2.up * force);
        int oxygenPerSecond = data.GetOxygenPerSecond(); 
        coinEffect.AddEffect("+" + oxygenPerSecond.ToString());
        onClick?.Invoke(oxygenPerSecond);
    }
}
