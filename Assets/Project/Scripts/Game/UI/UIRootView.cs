using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRootView : MonoBehaviour
{
    public ScreenClickerView screenClickerView;
    public ScreenUpgradeView screenUpgradeView;
    public ClickPopupPool clickPopupPool;
    
    [SerializeField] private GameObject loadScreen;

    public void ShowClickerScreen()
    {
        screenClickerView.gameObject.SetActive(true);
        screenUpgradeView.gameObject.SetActive(false);
    }

    public void ShowUpgradeScreen()
    {
        screenUpgradeView.gameObject.SetActive(true);
        screenClickerView.gameObject.SetActive(false);
    }
    public void ActiveLoadingScreen(bool value)
    {
        loadScreen.SetActive(value);
    }
}