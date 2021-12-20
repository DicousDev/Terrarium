using UnityEngine;
using TMPro;

public class AddCoinEffect : MonoBehaviour 
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject textMeshPrefab;

    public void AddEffect(string message)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject text = Instantiate(textMeshPrefab);
        text.transform.SetParent(parent, false);
        text.transform.position = mousePosition;

        text.GetComponent<TextMeshProUGUI>().text = message;
    }
}