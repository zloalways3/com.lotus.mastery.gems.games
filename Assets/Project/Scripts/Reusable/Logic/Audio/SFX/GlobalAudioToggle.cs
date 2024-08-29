using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class GlobalAudioToggle : ToggleSubscriber
{
    protected override void Listener(bool value)
    {
        if (value) GlobalSoundsData.Enable();
        else GlobalSoundsData.Disable();
    }

    private void OnEnable()
    {
        GetComponent<Toggle>().isOn =
            PlayerPrefs.GetInt(GlobalSoundsData.IsPlayingKey, 1) == 1;
    }
}