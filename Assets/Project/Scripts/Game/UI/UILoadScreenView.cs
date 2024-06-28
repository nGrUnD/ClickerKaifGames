using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoadScreenView : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;

    public void ActiveLoadingScreen(bool value)
    {
        loadingScreen.SetActive(value);
    }
}
