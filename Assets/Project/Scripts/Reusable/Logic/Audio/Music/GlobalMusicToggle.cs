using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class GlobalMusicToggle : ToggleSubscriber
{
    protected override void Listener(bool value)
    {
        if (value) GlobalMusicInfo.Enable();
        else GlobalMusicInfo.Disable();
    }

    private void OnEnable()
    {
        GetComponent<Toggle>().isOn = PlayerPrefs.GetInt(GlobalMusicInfo.PlayingKey, 1) == 1;
    }
}