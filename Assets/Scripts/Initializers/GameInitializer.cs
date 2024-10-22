using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private EventSystemSingleton _eventSystemSingleton;

    private void Awake()
    {
        InitializeManagers();
    }

    private void InitializeManagers()
    {
        _eventSystemSingleton = EventSystemSingleton.Instance;
    }
}
