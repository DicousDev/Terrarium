using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CartManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cartText;
    [SerializeField] private Button cartButton;
    [SerializeField] private GameObject cartView;
    [SerializeField] private bool cartOpen = false;
    [SerializeField] private PlantPreview previewPrefab;
    [SerializeField] private Transform containerPreview;
    [SerializeField] private List<PlantData> plantsList = new List<PlantData>();

    void OnEnable() 
    {
        GameStart.onGameStart += () => cartButton.onClick.AddListener(OpenCloseCart);
        GameStart.onGameStart += () => OpenCloseCart(cartOpen);
        GameStart.onGameStart += LoadCart;
        PlantPreview.onAddPlant += CloseCart;
    }

    void OnDisable() 
    {
        PlantPreview.onAddPlant -= CloseCart;
    }

    void LoadCart()
    {
        for(int i = 0; i < plantsList.Count; i++)
        {
            PlantData data = plantsList[i];
            data.Initialize();
            PlantPreview preview = Instantiate(previewPrefab);
            preview.transform.SetParent(containerPreview, false);
            preview.Initialize(data);
        }
    }

    void OpenCloseCart()
    {
        OpenCloseCart(!cartOpen);
    }

    void CloseCart()
    {
        OpenCloseCart(false);
    }

    void OpenCloseCart(bool value)
    {
        cartOpen = value;
        cartView.SetActive(cartOpen);
        cartText.text = cartOpen ? "Close" : "Open";
    }
}
