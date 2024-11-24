using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class ManagerInitializer : MonoBehaviour
{
    private EventSystemSingleton _eventSystemSingleton;
    private SceneLoadManager _sceneLoadManager;

    private void Awake()
    {
        InitializeOllManagers();

        InitializeGameStart();
    }

    private void InitializeOllManagers()
    {
        InitializeEventSystem();

        InitializeSceneLoadManager();
    }

    private void InitializeSceneLoadManager()
    {
        _sceneLoadManager = SceneLoadManager.Instance;
    }

    private void InitializeEventSystem()
    {
        _eventSystemSingleton = EventSystemSingleton.Instance;
    }

    private void InitializeGameStart()
    {
        SceneManager.LoadSceneAsync(SceneNameEnum.LoadingScene.ToString(), LoadSceneMode.Additive)
            .completed += LoadSceneStart;
    }

    private void LoadSceneStart(AsyncOperation operation)
    {
        _sceneLoadManager.LoadScene(loadScene: SceneNameEnum.MainScene, unloadScene: SceneNameEnum.Initialization);
    }
}
