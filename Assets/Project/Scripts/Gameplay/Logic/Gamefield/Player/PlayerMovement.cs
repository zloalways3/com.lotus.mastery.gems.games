using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Min(0.1f)] private float _speed = 1f;

    public event Action<PlayerMovementDirection> DirectionChanged;

    private Rigidbody2D _body;
    private PlayerMovementDirection _lastDirection = PlayerMovementDirection.Right;

    public bool TryMove(PlayerMovementDirection rawDirection)
    {
        if (GamePause.IsPaused) return false;

        var position = _body.position;
        var direction = Vector2.right * (int)rawDirection;
        var offset = position + direction * _speed * Time.fixedDeltaTime;

        _body.MovePosition(offset);

        if (rawDirection != _lastDirection) DirectionChanged?.Invoke(rawDirection);

        _lastDirection = rawDirection;

        return true;
    }

    private void Awake() => _body = GetComponent<Rigidbody2D>();
}