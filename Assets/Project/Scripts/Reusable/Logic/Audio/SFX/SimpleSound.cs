public abstract class SimpleSound : SimpleAudio
{
    public bool TryPlay()
    {
        if (!GlobalSoundsData.IsPlaying) return false;

        AudioSource.Play();
        return true;
    }

    private void Start()
    {
        AudioSource.loop = false;
        AudioSource.playOnAwake = false;

        SwitchEnabled(GlobalSoundsData.IsPlaying);

        GlobalSoundsData.Toggled += SwitchEnabled;
    }

    private void SwitchEnabled(bool value)
    {
        AudioSource.mute = !value;
    }
    private void OnDestroy()
    {
        GlobalSoundsData.Toggled -= SwitchEnabled;
    }
}