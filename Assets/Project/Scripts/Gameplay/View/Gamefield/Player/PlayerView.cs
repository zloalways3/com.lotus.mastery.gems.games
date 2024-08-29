using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _playerMovement.DirectionChanged += ShowChangedDirection;
    }

    private void ShowChangedDirection(PlayerMovementDirection direction)
    {
        _renderer.flipX = !_renderer.flipX;
    }

    private void OnDestroy()
    {
        _playerMovement.DirectionChanged -= ShowChangedDirection;
    }
}