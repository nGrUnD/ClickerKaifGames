using System;
using UnityEngine;

[Serializable]
public sealed class CurrencyStorage
{
    public event Action<int> OnCurrencyChanged;

    public int Currency
    {
        get { return currency; }
    }

    [SerializeField] private int currency;

    public void SetupCurrency(int value)
    {
        currency = value;
    }

    public void AddCurrency(int value)
    {
        currency += value;
        OnCurrencyChanged?.Invoke(Currency);
    }

    public void SpendCurrency(int value)
    {
        currency -= value;
        OnCurrencyChanged?.Invoke(Currency);
    }
}