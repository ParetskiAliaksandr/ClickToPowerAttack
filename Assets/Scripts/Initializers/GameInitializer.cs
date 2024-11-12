using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private EventSystemSingleton _eventSystemSingleton;

    private void Awake()
    {
        InitializeEventSystem();

        LoadScene();
    }

    private void LoadScene()
    {
        SceneLoadManager.Instance.LoadScene();
    }

    private void InitializeEventSystem()
    {
        _eventSystemSingleton = EventSystemSingleton.Instance;
    }
}
