using UnityEngine;
using Zenject;

public class UpgradeSystem : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UpgradePresenter>().AsSingle().NonLazy();
    }
}
