using UnityEngine;

public class SceneLoadingButton : ButtonSubscriber
{
    [SerializeField] private string _name;

    protected override void Listener()
    {
        SceneLoading.Load(_name);
    }
}