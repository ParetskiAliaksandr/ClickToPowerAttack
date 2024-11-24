using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static readonly object _lock = new object();
    private static T _instance;

    public static bool _isShuttingDown = false;

    public static T Instance
    {
        get
        {
            if (_isShuttingDown)
            {
                Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed. Returning null.");
                return null;
            }

            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (_instance == null)
                    {
                        SetupInstance();
                    }
                }

                return _instance;
            }
        }
    }

    public virtual void Awake()
    {
        RemoveDuplicates();
    }

    private static void SetupInstance()
    {
        var singletonObject = new GameObject();

        _instance = singletonObject.AddComponent<T>();

        singletonObject.name = typeof(T).ToString() + " (Singleton)";

        DontDestroyOnLoad(_instance.gameObject);
    }

    private void RemoveDuplicates()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(_instance.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        _isShuttingDown = true;
    }
}
