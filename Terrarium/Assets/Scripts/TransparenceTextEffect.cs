using System.Collections;
using UnityEngine;
using TMPro;

public class TransparenceTextEffect : MonoBehaviour 
{
    private float timeCurrent;
    private Color colorPattern;
    [SerializeField] private float durationInSecondsTotal = 3.0f;
    [SerializeField] private TextMeshProUGUI textMesh;

    void Start() 
    {
        colorPattern = textMesh.color;
    }

    void Update() 
    {
        timeCurrent += Time.deltaTime;
        textMesh.color = Color.Lerp(colorPattern, new Color(255, 255, 255, 0), timeCurrent / durationInSecondsTotal);

        if(timeCurrent >= durationInSecondsTotal)
        {
            Destroy(this.gameObject);
        }
    }
}