using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour
{
    [SerializeField] private Image barImage;

    private int _value;
    private int _maxValue;

    public void Init(int value, int maxValue)
    {
        _value = value;
        _maxValue = maxValue;
    }

    public void UpdateBar(int value)
    {
        _value = value;
        barImage.fillAmount = (float)_value / _maxValue;
    }
}
