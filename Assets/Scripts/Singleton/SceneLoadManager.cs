using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : Singleton<SceneLoadManager>
{
    private float _sceneLoadProgress;

    public static event Action<float> OnSceneLoadProgressChanged;
    public static event Action<bool> OnActivateSceneLoadeIndicator;
    public static event Action OnActivateBrightenScreenAnim;

    public void LoadScene(SceneNameEnum loadScene, SceneNameEnum unloadScene)
    {
        StartCoroutine(LoadSceneCoroutine(loadScene.ToString(), unloadScene.ToString()));
    }

    private IEnumerator LoadSceneCoroutine(string loadSceneName, string unloadSceneName)
    {
        yield return new WaitForSeconds(3.0f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(loadSceneName, LoadSceneMode.Additive);

        operation.allowSceneActivation = false;

        Debug.Log("Loade Scene Indicator activated!");
        OnActivateSceneLoadeIndicator?.Invoke(true); // SceneLoadingIndicator

        while (operation.progress < 0.9f)
        {
            _sceneLoadProgress = Mathf.Clamp01(operation.progress / 0.9f);

            OnSceneLoadProgressChanged?.Invoke(_sceneLoadProgress); // SceneLoadingIndicator

            Debug.Log($"Загрузка сцены в данный момент {_sceneLoadProgress:F2}");

            yield return null;
        }

        Debug.Log("Загрузка сцены завершена на 90%. Готовимся к активации...");

        _sceneLoadProgress = 1.0f;

        OnSceneLoadProgressChanged?.Invoke(_sceneLoadProgress); // SceneLoadingIndicator

        operation.allowSceneActivation = true;

        while (!operation.isDone)
        {
            yield return null;
        }

        Debug.Log("Сцена успешно загружена и активирована.");

        if (operation.isDone)
        {
            Debug.Log("Loade Scene Indicator deactivated!");

            OnActivateSceneLoadeIndicator?.Invoke(false); // SceneLoadingIndicator
            OnActivateBrightenScreenAnim?.Invoke(); // ScreenFader

            Debug.Log("Unload Scene " + unloadSceneName);

            SceneManager.UnloadSceneAsync(unloadSceneName);
        }

        yield return null;
    }
}