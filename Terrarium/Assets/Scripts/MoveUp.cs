using UnityEngine;

public class MoveUp : MonoBehaviour 
{
    [SerializeField] private float speed = 1;

    void Update() 
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}