using UnityEngine;

public class AutoResume : MonoBehaviour
{
    private void Awake() => GamePause.TryResume();
}