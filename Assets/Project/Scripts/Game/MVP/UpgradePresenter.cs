using UnityEngine.XR;
using Zenject;

public class UpgradePresenter
{
    private readonly ProductModel[] _products;
    private readonly ScreenUpgradeView _screenUpgradeView;
    private readonly CurrencyStorage _currencyStorage;
    private readonly ClickerModel _clickerModel;

    [Inject]
    public UpgradePresenter(
        ProductData productData,
        UIRootView rootUIView,
        CurrencyStorage currencyStorage,
        ClickerModel clickerModel
    )
    {
        _products = productData.products;
        _screenUpgradeView = rootUIView.screenUpgradeView;
        _currencyStorage = currencyStorage;
        _clickerModel = clickerModel;

        _currencyStorage.OnCurrencyChanged += i => { UpdateView(); };
        _screenUpgradeView.OnPurchaseEvent += HandlePurchase;

        LoadProducts();
    }

    private void LoadProducts()
    {
        for (int i = 0; i < _products.Length; i++)
        {
            var product = _products[i];
            product.Load();
            _screenUpgradeView.AddProductView(product, i);
        }
    }

    private void HandlePurchase(int index)
    {
        var upgrade = _products[index];
        if (!upgrade.IsPurchased && _currencyStorage.Currency >= upgrade.Cost)
        {
            _currencyStorage.SpendCurrency(upgrade.Cost);
            _clickerModel.UpgradeClickPower(upgrade.AdditionalPower);
            upgrade.IsPurchased = true;
            upgrade.Save();
            _screenUpgradeView.UpdateProductViewState(index, true);
            _clickerModel.SaveProgress();
            UpdateView();
        }
    }

    private void UpdateView()
    {
        _screenUpgradeView.SetCurrencyText($"Валюта:{_currencyStorage.Currency}");
    }
}