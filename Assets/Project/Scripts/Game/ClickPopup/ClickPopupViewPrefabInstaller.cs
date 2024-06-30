using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ClickPopupViewPrefabInstaller : MonoInstaller
{
    [SerializeField] private ClickPopupView clickPopupViewPrefab;
    public override void InstallBindings()
    {
        Container.Bind<ClickPopupView>().FromComponentInNewPrefab(clickPopupViewPrefab).AsTransient();
    }
}

