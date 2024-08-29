using System;

public class DangerThing : Thing
{
    public static event Action Collected;

    protected override void HandlePickuped() => Collected?.Invoke();
}