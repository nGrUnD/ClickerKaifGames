using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var rootUIView = FindObjectOfType<UIRootView>();
        Container.Bind<UIRootView>().FromInstance(rootUIView).AsSingle();
    }
}