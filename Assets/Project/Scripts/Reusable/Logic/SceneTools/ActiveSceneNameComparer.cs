using UnityEngine.SceneManagement;

public static class ActiveSceneNameComparer
{
    public static bool CompareActiveSceneName(string name)
    {
        return SceneManager.GetActiveScene().name == name;
    }
}