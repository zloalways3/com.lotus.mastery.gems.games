using UnityEngine;

public class AutoSceneLoadRequest : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void Start()
    {
        SceneLoading.Load(_sceneName);
    }
}