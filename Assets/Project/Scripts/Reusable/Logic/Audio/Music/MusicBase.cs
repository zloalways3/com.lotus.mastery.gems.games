public abstract class MusicBase : SimpleAudio
{
    public bool TryPlay()
    {
        if (!GlobalMusicInfo.IsPlaying) return false;

        AudioSource.Play();
        return true;
    }

    private void Start()
    {
        AudioSource.playOnAwake = false;
        AudioSource.loop = true;

        SwitchEnabled(GlobalMusicInfo.IsPlaying);

        GlobalMusicInfo.Toggled += SwitchEnabled;
    }

    private void SwitchEnabled(bool value)
    {
        AudioSource.mute = !value;
    }

    private void OnDestroy()
    {
        GlobalMusicInfo.Toggled -= SwitchEnabled;
    }
}