using UnityEngine;

public class PlayerThingPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Thing item)) return;

        item.Pickup();
    }
}