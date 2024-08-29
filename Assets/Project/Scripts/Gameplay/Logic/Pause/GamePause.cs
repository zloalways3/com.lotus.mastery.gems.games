using System;

public static class GamePause
{
    private const string AvaibleScene = "Level";

    public static event Action Paused;
    public static event Action Resumed;

    public static bool IsPaused { get; private set; }

    public static bool TryPause()
    {
        if (!ActiveSceneNameComparer.CompareActiveSceneName(AvaibleScene)) return false;
        if (IsPaused) return false;

        SetPause();

        return true;
    }

    public static bool TryResume()
    {
        if (!ActiveSceneNameComparer.CompareActiveSceneName(AvaibleScene)) return false;
        if (!IsPaused) return false;

        SetResume();

        return true;
    }

    private static void SetPause()
    {
        IsPaused = true;
        Paused?.Invoke();
    }

    private static void SetResume()
    {
        IsPaused = false;
        Resumed?.Invoke();
    }
}