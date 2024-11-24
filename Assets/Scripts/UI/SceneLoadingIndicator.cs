using System;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoadingIndicator : MonoBehaviour
{
    [SerializeField] private RectTransform _indicator;
    [SerializeField] private Image _spinningIndicator;

    private void OnEnable()
    {
        SceneLoadManager.Instance.OnSceneLoadProgressChanged += OnUpdateProgressBar;
        SceneLoadManager.Instance.OnActivateSceneLoadeIndicator += OnActivateIndicator;
    }

    private void OnActivateIndicator(bool isIndicatorActivated)
    {
        Debug.Log($"Метод OnActivateIndicator сработал!");

        _indicator.gameObject.SetActive(isIndicatorActivated);

        DebugUIState();
    }

    private void OnUpdateProgressBar(float sceneLoadProgress)
    {
        Debug.Log($"Метод OnUpdateProgressBar сработал! {sceneLoadProgress}");

        if (_spinningIndicator == null)
        {
            Debug.LogError("Spinning Indicator is null. Check assignment.");
            return;
        }

        _spinningIndicator.fillAmount = sceneLoadProgress;

        DebugUIState();
    }

    private void DebugUIState()
    {
        Debug.Log($"Indicator active: {_indicator?.gameObject.activeSelf}");
        Debug.Log($"Spinning Indicator active: {_spinningIndicator?.gameObject.activeSelf}");
        Debug.Log($"Fill Amount: {_spinningIndicator?.fillAmount}");
    }

    private void OnDisable()
    {
        if (SceneLoadManager.Instance == null || SceneLoadManager._isShuttingDown)
        {
            return;
        }

        SceneLoadManager.Instance.OnSceneLoadProgressChanged -= OnUpdateProgressBar;
        SceneLoadManager.Instance.OnActivateSceneLoadeIndicator -= OnActivateIndicator;
    }

    private void OnDestroy()
    {
        OnDisable();
    }
}
