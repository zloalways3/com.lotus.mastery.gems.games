using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ThingDeathZone : MonoBehaviour
{
    [SerializeField] private ThingFalling _itemFalling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Thing item)) return;

        _itemFalling.SetVelocity(item);
    }
}