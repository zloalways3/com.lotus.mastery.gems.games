using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class MovePlayerButton : MonoBehaviour
{
    [SerializeField] private PlayerMovementDirection _direction;
    [SerializeField] private PlayerMovement _playerMovement;

    private EventTrigger _eventTrigger;

    private bool _inHolding;

    private void Awake()
    {
        _eventTrigger = GetComponent<EventTrigger>();

        var pointerDown = new EventTrigger.Entry();
        var pointerUp = new EventTrigger.Entry();

        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerUp.eventID = EventTriggerType.PointerUp;

        pointerDown.callback.AddListener((_) => _inHolding = true);
        pointerUp.callback.AddListener((_) => _inHolding = false);

        _eventTrigger.triggers.Add(pointerDown);
        _eventTrigger.triggers.Add(pointerUp);
    }

    private void Update()
    {
        if (!_inHolding) return;

        _playerMovement.TryMove(_direction);
    }
}