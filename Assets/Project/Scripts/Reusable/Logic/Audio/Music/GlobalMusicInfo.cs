using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEngine.SceneManagement;
#endif

public class GlobalMusicInfo : MonoBehaviour
{
    public static event Action<bool> Toggled;

    [SerializeField] private BackgroundLoop _backgroundLoop;
    private static BackgroundLoop _backgroundLoopStatic;

    public static bool IsPlaying { get; private set; }
    public static string PlayingKey => $"{nameof(GlobalMusicInfo)}_{nameof(IsPlaying)}";

    public static void Enable()
    {
        Toggled?.Invoke(IsPlaying = true);
        PlayerPrefs.SetInt(PlayingKey, 1);
    }

    public static void Disable()
    {
        Toggled?.Invoke(IsPlaying = false);
        PlayerPrefs.SetInt(PlayingKey, 0);
    }

    public static bool TryPlayBackgroundMusic()
    {
#if UNITY_EDITOR
        if (_backgroundLoopStatic == null) throw new Exception($"Add component \"{nameof(BackgroundLoop)}\" to scene \"{SceneManager.GetActiveScene().name}\" or provide a reference in field \"{nameof(_backgroundLoop)}\" if it already exists");
#endif
        return _backgroundLoopStatic.TryPlay();
    }

    private void Awake()
    {
        var musics = FindObjectsOfType<GlobalMusicInfo>();

        foreach (var music in musics)
            if (music != this)
                Destroy(music.gameObject);

        DontDestroyOnLoad(gameObject);

        _backgroundLoopStatic = _backgroundLoop;

        var enabled = PlayerPrefs.GetInt(PlayingKey, 1) == 1;

        if (enabled) Enable();
        else Disable();
    }
}