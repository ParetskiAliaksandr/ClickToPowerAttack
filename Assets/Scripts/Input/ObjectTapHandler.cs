using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ObjectTapHandler : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReaderSO;
    [SerializeField] private List<RectTransform> UIEllements = new List<RectTransform>();
    [SerializeField] private TMP_Text _text;

    private int _tapCount;

    private void Awake()
    {
        _text.text = "0";
        _tapCount = 0;
    }

    private void OnEnable()
    {
        _inputReaderSO.onTouchEvent += HandleTapInput;
    }

    public void HandleTapInput(Vector2 touchPosition)
    {
        foreach (RectTransform uiEllement in UIEllements)
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(uiEllement, touchPosition, null))
            {
                _tapCount = _tapCount + 1;
                _text.text = _tapCount.ToString();
            }
            else
            {
                Debug.Log("Button is Press!");
                _inputReaderSO.DisableGameplayActionMap();
            }
        }
    }

    private void OnDisable()
    {
        _inputReaderSO.onTouchEvent -= HandleTapInput;
    }
}
