using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public class ClickPopupView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI valueText;
    private ClickPopupPool _pool;

    public void Initialize(string text, ClickPopupPool pool)
    {
        _pool = pool;
        SetValueText(text);
        SetViewPositionAtMouse();
        AnimateView();
    }

    private void SetViewPositionAtMouse()
    {
        var mousePosition = Input.mousePosition;
        transform.position = mousePosition;
    }


    public void SetValueText(string value)
    {
        valueText.text = value;
    }

    public void AnimateView()
    {
        valueText.DOFade(1f, 0f);
        transform.DOMoveY(transform.position.y + 200f, 2.0f).SetEase(Ease.OutCubic);
        valueText.DOFade(0, 2.0f).OnComplete(() => _pool.Release(this));
    }
}