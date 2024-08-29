public class ToggleClickSound : ToggleSubscriber
{
    protected override void Listener()
    {
        GlobalSoundsData.TryPlayClick();
    }
}