using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public event Action Died;

    private void Awake() => DangerThing.Collected += Die;

    private void Die()
    {
        Destroy(gameObject);
        GamePause.TryPause();
        Died?.Invoke();
    }

    private void OnDestroy() => DangerThing.Collected -= Die;
}