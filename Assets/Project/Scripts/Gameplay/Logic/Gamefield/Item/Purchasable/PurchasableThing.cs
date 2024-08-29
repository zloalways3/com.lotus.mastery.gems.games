using UnityEngine;

public class PurchasableThing : Thing, IPurchasable
{
    [SerializeField] [Min(1)] private int _price = 1;

    public int Price => _price;

    protected override void HandlePickuped()
    {
        Balance.TryTopUp(this);
    }
}