using UnityEngine;

public abstract class SimpleSubscriber : MonoBehaviour
{
    private void Start()
    {
        Subscribe();
    }

    protected virtual void Listener() { }
    protected abstract void Subscribe();
}