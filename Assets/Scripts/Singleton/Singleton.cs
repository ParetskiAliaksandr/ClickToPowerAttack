using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static readonly object _lock = new object();
    private static T _instance;

    private static bool _isShuttingDown = false;
    public static bool IsShuttingDown 
    {
        get { return _isShuttingDown; }
        set { _isShuttingDown = value; }
    }

    public static T Instance
    {
        get
        {
            if (IsShuttingDown)
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
        IsShuttingDown = true;
    }
}
