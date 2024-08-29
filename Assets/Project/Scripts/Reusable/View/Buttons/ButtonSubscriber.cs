using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonSubscriber : SimpleSubscriber
{
    protected Button Button { get; private set; }

    protected override void Subscribe()
    {
        GetComponent<Button>().onClick.AddListener(Listener);
    }
}