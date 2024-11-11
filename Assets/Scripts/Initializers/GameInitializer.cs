using System;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private EventSystemSingleton _eventSystemSingleton;

    private void Awake()
    {
        InitializeEventSystem();

        InitializeScene();
    }

    private void InitializeScene()
    {
        
    }

    private void InitializeEventSystem()
    {
        _eventSystemSingleton = EventSystemSingleton.Instance;
    }
}
