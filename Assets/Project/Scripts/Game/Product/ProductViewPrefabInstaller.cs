using UnityEngine;
using Zenject;

public class ProductViewPrefabInstaller : MonoInstaller
{
    [SerializeField] private ProductView productViewPrefab;
    public override void InstallBindings()
    {
        Container.Bind<ProductView>().FromComponentInNewPrefab(productViewPrefab).AsTransient();
    }
}