using UnityEngine.SceneManagement;

public class SceneLoadManager : Singleton<SceneLoadManager>
{
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }
}