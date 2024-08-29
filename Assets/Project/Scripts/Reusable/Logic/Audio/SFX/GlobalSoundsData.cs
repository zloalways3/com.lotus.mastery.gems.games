using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEngine.SceneManagement;
#endif

public class GlobalSoundsData : MonoBehaviour
{
    public static event Action<bool> Toggled;

    [SerializeField] private ClickSound _clickSound;
    private static ClickSound _clickSoundStatic;

    public static bool IsPlaying { get; private set; }
    public static string IsPlayingKey => $"{nameof(GlobalSoundsData)}_{nameof(IsPlaying)}";

    public static void Enable()
    {
        Toggled?.Invoke(IsPlaying = true);
        PlayerPrefs.SetInt(IsPlayingKey, 1);
    }

    public static void Disable()
    {
        Toggled?.Invoke(IsPlaying = false);
        PlayerPrefs.SetInt(IsPlayingKey, 0);
    }

    public static bool TryPlayClick()
    {
#if UNITY_EDITOR
        if (_clickSoundStatic == null) throw new Exception($"Add component \"{nameof(ClickSound)}\" to scene \"{SceneManager.GetActiveScene().name}\" or provide a reference in field \"{nameof(_clickSound)}\" if it already exists");
#endif
        return _clickSoundStatic.TryPlay();
    }

    private void Awake()
    {
        var sounds = FindObjectsOfType<GlobalSoundsData>();

        foreach(var sound in sounds)
            if (sound != this)
                Destroy(sound.gameObject);

        DontDestroyOnLoad(gameObject);

        _clickSoundStatic = _clickSound;

        var enabled = PlayerPrefs.GetInt(IsPlayingKey, 1) == 1;

        if (enabled) Enable();
        else Disable();
    }
}