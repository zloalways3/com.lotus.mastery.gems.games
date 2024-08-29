using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public abstract class SimpleAudio : MonoBehaviour
{
    protected AudioSource AudioSource { get; private set; }

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();

        AudioSource.mute = false;
    }
}