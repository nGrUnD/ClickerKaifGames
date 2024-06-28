using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CurrencySystem : MonoInstaller
{
    [SerializeField] private CurrencyStorage currencyStorage;

    public override void InstallBindings()
    {
        Container.Bind<CurrencyStorage>().FromInstance(currencyStorage);
    }
}