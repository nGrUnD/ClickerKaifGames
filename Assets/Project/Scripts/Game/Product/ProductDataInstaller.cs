using System;
using UnityEngine;
using Zenject;

[Serializable]
public class ProductData
{
    public ProductModel[] products;
}

[CreateAssetMenu(menuName = "Data/ProductData", fileName = "ProductDataInstaller", order = 0)]
public class ProductDataInstaller : ScriptableObjectInstaller
{
    [SerializeField] private ProductData productData;
    public override void InstallBindings()
    {
        Container.BindInstance(productData);
    }
}