using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoading
{
    private const int MillisecondsInSecond = 1000;
    private const float ProgressUpdateRate = 0.5f;

    public static event Action<float> ProgressUpdated;
    public static event Action Loaded;

    private static float _lastProgress;

    public static void RestartScene()
    {
        var name = SceneManager.GetActiveScene().name;
        Load(name);
    }

    public static async void Load(string name)
    {
        var loading = SceneManager.LoadSceneAsync(name);

        while (!loading.isDone)
        {
            var progress = loading.progress;

            if (progress != _lastProgress) ProgressUpdated?.Invoke(progress);
            _lastProgress = progress;

            var delay = Mathf.RoundToInt(ProgressUpdateRate * MillisecondsInSecond);
            await Task.Delay(delay);
        }

        Loaded?.Invoke();
    }
}