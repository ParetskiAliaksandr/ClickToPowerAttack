using UnityEngine;

public class ManagerInitializer : MonoBehaviour
{
    private EventSystemSingleton _eventSystemSingleton;
    private SceneLoadManager _sceneLoadManager;

    private void Awake()
    {
        InitializeEventSystem();

        InitialiizeSceneLoadManager();
    }

    private void InitialiizeSceneLoadManager()
    {
        _sceneLoadManager = SceneLoadManager.Instance;
    }

    private void InitializeEventSystem()
    {
        _eventSystemSingleton = EventSystemSingleton.Instance;
    }
}
