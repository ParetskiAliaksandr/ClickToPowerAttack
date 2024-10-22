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

                DontDestroyOnLoad(_instance.gameObject);
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
        }
        else
        {
            Debug.LogError("EventSystem not found in Resources foulder!");
        }
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
