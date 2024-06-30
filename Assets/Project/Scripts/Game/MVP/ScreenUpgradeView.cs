using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenUpgradeView : MonoBehaviour
{
    public event Action<int> OnPurchaseEvent;

    [SerializeField] private Transform productListParent;
    [SerializeField] private ProductView productViewPrefab;
    [SerializeField] private TextMeshProUGUI currencyText;

    private List<ProductView> productViewList = new();

    public void AddProductView(ProductModel productModel, int index)
    {
        var productView = Instantiate(productViewPrefab, productListParent);
        productView.SetCostText($"${productModel.Cost}");
        productView.SetNameText(productModel.Name);
        productView.SetDescriptionText(productModel.Description);
        productView.SetBuyButtonState(!productModel.IsPurchased);
        productView.OnPurchaseEvent += () => { OnPurchaseEvent?.Invoke(index); };
        productViewList.Add(productView);
    }

    public void UpdateProductViewState(int index, bool isPurchased)
    {
        productViewList[index].SetBuyButtonState(!isPurchased);
    }

    public void SetCurrencyText(string value)
    {
        currencyText.text = value;
    }
}