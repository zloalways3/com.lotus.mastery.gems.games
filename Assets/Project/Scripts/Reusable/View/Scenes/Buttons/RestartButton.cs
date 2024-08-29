public class RestartButton : ButtonSubscriber
{
    protected override void Listener()
    {
        SceneLoading.RestartScene();
    }
}