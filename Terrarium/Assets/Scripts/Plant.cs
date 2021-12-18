using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private PlantData data;
    [SerializeField] private Rigidbody2D rb;
    [Min(0)]
    [SerializeField] private float force = 50;

    void Start() 
    {
        InvokeRepeating("AddCoin", 1, 1);
    }

    void AddCoin()
    {
        GameManager.AddCoin(data.oxygenPerSecond);
    }

    public void SetPlantData(PlantData data)
    {
        this.data = data;
    }

    void OnMouseDown() 
    {
        if(data == null) return;
        
        rb.AddForce(Vector2.up * force);
        GameManager.AddCoin(data.oxygenPerSecond);
    }
}
