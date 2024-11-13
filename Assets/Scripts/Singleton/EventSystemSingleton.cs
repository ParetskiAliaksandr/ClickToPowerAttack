using UnityEngine;

public class EventSystemSingleton : MonoBehaviour
{
    private static EventSystemSingleton _instance;

    public static EventSystemSingleton Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<EventSystemSingleton>();

                if(_instance == null)
                {
                    SetupInstance();
                } 
            }

            return _instance;
        }   
    }

    private void Awake()
    {
        RemoveDuplicates();
    }

    private static void SetupInstance()
    {
        GameObject eventSystemPrefab = Resources.Load<GameObject>("EventSystem");

        if (eventSystemPrefab != null)
        {
            _instance = Instantiate(eventSystemPrefab).GetComponent<EventSystemSingleton>();

            _instance.gameObject.name = eventSystemPrefab.name + " (Singleton) ";
        }
        else
        {
            Debug.LogError("EventSystem not found in Resources foulder!");
        }

        DontDestroyOnLoad(_instance.gameObject);
    }

    private void RemoveDuplicates()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
