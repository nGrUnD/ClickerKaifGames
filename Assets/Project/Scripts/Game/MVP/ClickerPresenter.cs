using UnityEngine;
using UnityEngine.PlayerLoop;
using Zenject;

public class ClickerPresenter
{
    private readonly ClickerModel _clickerModel;
    private readonly ScreenClickerView _screenClickerView;
    private readonly ClickStorage _clickStorage;
    private readonly CurrencyStorage _currencyStorage;

    [Inject]
    public ClickerPresenter(
        ClickerModel clickerModel,
        UIRootView rootUIView,
        ClickStorage clickStorage,
        CurrencyStorage currencyStorage
    )
    {
        _clickerModel = clickerModel;
        _screenClickerView = rootUIView.screenClickerView;
        _clickStorage = clickStorage;
        _currencyStorage = currencyStorage;

        _screenClickerView.OnClickEvent += HandleClick;
        _currencyStorage.OnCurrencyChanged += OnCurrencyChanged;
        _clickStorage.OnClickCountChanged += OnClickCountChanged;
        _clickerModel.OnLevelUpEvent += UpdateProgressBar;

        UpdateProgressBar();
        UpdateView();
    }

    private void OnCurrencyChanged(int currency)
    {
        UpdateView();
        _screenClickerView.AnimateCurrencyText();
    }

    private void OnClickCountChanged(int clickCount)
    {
        UpdateView();
        _screenClickerView.AnimateClickCountText();
    }

    private void HandleClick()
    {
        _clickerModel.CreateClickPopup();
        _clickerModel.IncrementClick();
        _clickerModel.SaveProgress();
        UpdateView();
    }

    private void UpdateProgressBar()
    {
        _screenClickerView.ProgressBar.Init(_clickStorage.Count, _clickerModel.ClicksForNextLevel);
    }

    private void UpdateView()
    {
        _screenClickerView.SetCurrencyText($"Валюта:${_currencyStorage.Currency}");
        _screenClickerView.SetPerClickValueText(_clickerModel.Power.ToString());
        _screenClickerView.SetLevelText($"Уровень:{_clickerModel.Level}");
        _screenClickerView.SetTargetValueText($"До след уровня:{_clickerModel.ClicksForNextLevel}");
        _screenClickerView.ProgressBar.UpdateBar(_clickStorage.Count);
        _screenClickerView.SetClickCountText($"Клики:{_clickStorage.Count}");
        Canvas.ForceUpdateCanvases();
    }
}