using UnityEngine;

public class MovePlant : MonoBehaviour {

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform plantTransform;
    [Range(0f, 1f)]
    [SerializeField] private float moveSmooth = 0.363f;
    [SerializeField] private float timeDelay = 0.2f;
    private float nextTime;

    void Awake() 
    {
        this.plantTransform = transform;
    }

    void OnMouseDown() 
    {
        nextTime = Time.time + timeDelay;
    }

    void OnMouseDrag() 
    {
        if(Time.time < nextTime) 
            return;
        
        rb.isKinematic = true;
        Vector2 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        plantTransform.position = Vector3.Lerp(plantTransform.position, positionMouse, moveSmooth);
    }

    void OnMouseUp() 
    {
        rb.isKinematic = false;    
    }
}