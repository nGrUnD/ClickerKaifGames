using UnityEngine;
using Zenject;

public class ClickerSystem : MonoInstaller
{
    [SerializeField] private ClickStorage clickStorage;

    public override void InstallBindings()
    {
        Container.Bind<ClickerModel>().AsSingle();
        Container.Bind<ClickStorage>().FromInstance(clickStorage);       
        Container.Bind<ClickerPresenter>().AsSingle().NonLazy();
    }
}