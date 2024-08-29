using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public abstract class ToggleSubscriber : SimpleSubscriber
{
    protected virtual void Listener(bool value) { }
    protected virtual void Initialize() { }

    protected override void Subscribe()
    {
        var toggle = GetComponent<Toggle>();

        toggle.onValueChanged.AddListener((_) => Listener());
        toggle.onValueChanged.AddListener(Listener);

        Initialize();
    }
}