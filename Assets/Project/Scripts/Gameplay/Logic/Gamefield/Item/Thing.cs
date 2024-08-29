using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Thing : MonoBehaviour
{
    public static event Action<Thing> Spawned;
    public static event Action<Thing> Pickuped;

    [SerializeField] [Min(0.1f)] private float _fallingSpeed = 1f;

    private Vector2 _fallingVelocity;

    private Rigidbody2D _body;

    public float FallingSpeed => _fallingSpeed;
    public Rigidbody2D Body => _body;

    public void Pickup()
    {
        HandlePickuped();
        Pickuped?.Invoke(this);
    }

    protected abstract void HandlePickuped();

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();

        Spawned?.Invoke(this);

        GamePause.Paused += PauseItem;
        GamePause.Resumed += ResumeItem;
    }

    private void PauseItem()
    {
        _fallingVelocity = _body.velocity;
        _body.velocity = Vector2.zero;
    }

    private void ResumeItem()
    {
        _body.velocity = _fallingVelocity;
    }

    private void OnDestroy()
    {
        GamePause.Paused -= PauseItem;
        GamePause.Resumed -= ResumeItem;
    }
}