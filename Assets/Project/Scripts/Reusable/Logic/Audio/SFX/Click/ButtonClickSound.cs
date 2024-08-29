public class ButtonClickSound : ButtonSubscriber
{
    protected override void Listener() => GlobalSoundsData.TryPlayClick();
}