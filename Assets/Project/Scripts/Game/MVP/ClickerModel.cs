using System;
using UnityEngine;
using Zenject;

public class ClickerModel
{
    public event Action OnLevelUpEvent;
    public int Level { get; private set; }
    public int ClicksForNextLevel { get; private set; }
    public int Power { get; private set; }

    private readonly ClickStorage _clickStorage;
    private readonly CurrencyStorage _currencyStorage;
    private readonly ClickPopupPool _clickPopupPool;

    [Inject]
    public ClickerModel(ClickStorage clickStorage, CurrencyStorage currencyStorage, UIRootView rootUIView)
    {
        _clickStorage = clickStorage;
        _currencyStorage = currencyStorage;
        _clickPopupPool = rootUIView.clickPopupPool;

        LoadProgress();
    }

    public void IncrementClick()
    {
        _clickStorage.AddClick(Power);
        _currencyStorage.AddCurrency(Power);
        if (_clickStorage.Count >= ClicksForNextLevel)
        {
            LevelUp();
        }
    }

    public void CreateClickPopup()
    {
        var clickPopup = _clickPopupPool.Get();
        clickPopup.Initialize($"+{Power}", _clickPopupPool);
    }

    public void UpgradeClickPower(int value)
    {
        Power += value;
    }

    private void LevelUp()
    {
        Level++;
        _clickStorage.SetupCount(0);
        ClicksForNextLevel *= 2;
        OnLevelUpEvent?.Invoke();
    }

    public void SaveProgress()
    {
        SaveData data = new SaveData
        {
            ClickCount = _clickStorage.Count,
            ClickPower = Power,
            CurrentLevel = Level,
            ClicksForNextLevel = ClicksForNextLevel,
            Currency = _currencyStorage.Currency // Сохраняем валюту
        };

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SaveData", json);
        PlayerPrefs.Save();
    }

    public void LoadProgress()
    {
        if (PlayerPrefs.HasKey("SaveData"))
        {
            string json = PlayerPrefs.GetString("SaveData");
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            _clickStorage.SetupCount(data.ClickCount);
            Power = data.ClickPower;
            Level = data.CurrentLevel;
            ClicksForNextLevel = data.ClicksForNextLevel;
            _currencyStorage.SetupCurrency(data.Currency);
        }
        else
        {
            _clickStorage.SetupCount(0);
            Power = 1;
            Level = 1;
            ClicksForNextLevel = 10;
            _currencyStorage.SetupCurrency(0);
        }
    }
}