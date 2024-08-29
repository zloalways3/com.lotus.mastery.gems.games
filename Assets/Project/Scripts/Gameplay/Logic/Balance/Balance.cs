using System;

public static class Balance
{
    public static event Action<int> Updated;

    public static int Value { get; private set; }

    public static void Reset()
    {
        Value = 0;
        Updated?.Invoke(Value);
    }

    public static bool TryTopUp(IPurchasable purhasable)
    {
        if (purhasable.Price <= 0) return false;

        TopUp(purhasable);

        return true;
    }

    private static void TopUp(IPurchasable purhasable)
    {
        Value += purhasable.Price;
        Updated?.Invoke(Value);
    }
}