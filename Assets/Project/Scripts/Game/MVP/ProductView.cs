using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductView : MonoBehaviour
{
    public event Action OnPurchaseEvent;
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Button buyButton;

    private void Start()
    {
        buyButton.onClick.AddListener(HandlePurchase);
    }

    private void HandlePurchase()
    {
        OnPurchaseEvent?.Invoke();
    }    
    
    public void SetBuyButtonState(bool isEnabled)
    {
        buyButton.interactable = isEnabled;
    }


    public void SetNameText(string value)
    {
        nameText.text = value;
    }

    public void SetDescriptionText(string value)
    {
        descriptionText.text = value;
    }
    
    public void SetCostText(string value)
    {
        costText.text = value;
    }
}
