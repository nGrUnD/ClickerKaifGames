using System;
using UnityEngine;

[Serializable]
public sealed class ClickStorage
{
    public event Action<int> OnClickCountChanged;

    public int Count
    {
        get { return count; }
    }

    [SerializeField] private int count;

    public void SetupCount(int value)
    {
        count = value;
    }

    public void AddClick(int value)
    {
        count += value;
        OnClickCountChanged?.Invoke(count);
    }
}