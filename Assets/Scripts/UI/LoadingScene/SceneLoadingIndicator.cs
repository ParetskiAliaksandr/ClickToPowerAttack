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
        _indicator.gameObject.SetActive(isIndicatorActivated);
    }

    private void OnUpdateProgressBar(float sceneLoadProgress)
    {
        if (_spinningIndicator == null)
        {
            Debug.LogError("Spinning Indicator is null. Check assignment.");
            return;
        }

        _spinningIndicator.fillAmount = sceneLoadProgress;
    }

    private void OnDisable()
    {
        if (SceneLoadManager.Instance == null || SceneLoadManager.IsShuttingDown)
        {
            return;
        }

        SceneLoadManager.Instance.OnSceneLoadProgressChanged -= OnUpdateProgressBar;
        SceneLoadManager.Instance.OnActivateSceneLoadeIndicator -= OnActivateIndicator;
    }
}
