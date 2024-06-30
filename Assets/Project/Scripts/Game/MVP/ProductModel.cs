using System;
using UnityEngine;

[Serializable]
public class ProductModel
{
    public string Name;
    [TextArea]
    public string Description;
    public int Cost;
    public int AdditionalPower;
    public bool IsPurchased;
    
    public void Save()
    {
        PlayerPrefs.SetInt($"{Name}_IsPurchased", IsPurchased ? 1 : 0);
    }

    public void Load()
    {
        IsPurchased = PlayerPrefs.GetInt($"{Name}_IsPurchased", 0) == 1;
    }

}
