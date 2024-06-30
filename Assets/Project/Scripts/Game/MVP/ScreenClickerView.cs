using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class ScreenClickerView : MonoBehaviour
{
    public event Action OnClickEvent;
    public UIProgressBar ProgressBar => progressBar;

    [SerializeField] private UIProgressBar progressBar;
    [SerializeField] private Button clickObjectButton;
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private TextMeshProUGUI perClickValueText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI targetValueText;
    [SerializeField] private TextMeshProUGUI clickCountText;

    private void Start()
    {
        clickObjectButton.onClick.AddListener(HandleClick);
    }

    private void HandleClick()
    {
        OnClickEvent?.Invoke();
    }

    public void SetPerClickValueText(string value)
    {
        perClickValueText.text = value;
    }

    public void SetCurrencyText(string value)
    {
        currencyText.text = value;
    }

    public void SetLevelText(string value)
    {
        levelText.text = value;
    }

    public void SetTargetValueText(string value)
    {
        targetValueText.text = value;
    }

    public void SetClickCountText(string value)
    {
        clickCountText.text = value;
    }

    public void AnimateCurrencyText()
    {
        DOTween
            .Sequence()
            .Append(currencyText.transform.DOScale(Vector3.one * 1.2f, 0.2f))
            .Append(currencyText.transform.DOScale(Vector3.one, 0.2f));
    }


    public void AnimateClickCountText()
    {
        DOTween
            .Sequence()
            .Append(clickCountText.transform.DOScale(Vector3.one * 1.2f, 0.2f))
            .Append(clickCountText.transform.DOScale(Vector3.one, 0.2f));
    }
}