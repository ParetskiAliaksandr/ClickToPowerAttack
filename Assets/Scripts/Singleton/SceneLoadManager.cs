using UnityEngine.SceneManagement;

public class SceneLoadManager : Singleton<SceneLoadManager>
{
    public void LoadScene(SceneNameEnum sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName.ToString());
    }
}