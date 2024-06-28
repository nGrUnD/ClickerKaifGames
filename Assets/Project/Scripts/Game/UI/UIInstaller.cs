using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    private const string PATH_INTERFACE = "[INTERFACE]";

    public override void InstallBindings()
    {
        Container.Bind<ScreenClickerView>().FromComponentInNewPrefabResource(PATH_INTERFACE).AsSingle();
    }
}