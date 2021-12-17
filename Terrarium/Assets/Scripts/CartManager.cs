using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CartManager : MonoBehaviour
{
    public static CartManager instance;
    [SerializeField] private TextMeshProUGUI cartText;
    [SerializeField] private Button cartButton;
    [SerializeField] private GameObject cartView;
    [SerializeField] private bool cartOpen = false;
    [SerializeField] private PlantPreview previewPrefab;
    [SerializeField] private Transform containerPreview;
    [SerializeField] private List<PlantData> plantsList = new List<PlantData>();

    void Awake()
    {
        if(instance == null) 
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        cartButton.onClick.AddListener(OpenCloseCart);
        OpenCloseCart(cartOpen);
    }

    void Start() => LoadCart();

    void LoadCart()
    {
        for(int i = 0; i < plantsList.Count; i++)
        {
            PlantData data = plantsList[i];
            PlantPreview preview = Instantiate(previewPrefab);
            preview.transform.SetParent(containerPreview, false);
            preview.Initialize(data);
        }
    }

    public void OpenCloseCart()
    {
        OpenCloseCart(!cartOpen);
    }

    public void CloseCart()
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
