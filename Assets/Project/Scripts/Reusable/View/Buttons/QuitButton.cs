using UnityEngine;

public class QuitButton : ButtonSubscriber
{
    protected override void Listener()
    {
        Application.Quit();
    }
}