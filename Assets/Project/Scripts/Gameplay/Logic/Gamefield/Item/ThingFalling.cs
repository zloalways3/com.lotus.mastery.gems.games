using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThingFalling : MonoBehaviour
{
    [SerializeField] [Min(0.1f)] private float _minFallingDelay = 0.5f;
    [SerializeField] [Min(0.1f)] private float _maxFallingDelay = 1f;

    [SerializeField] [Min(0.1f)] private float _fallingWidth = 1f;

    [SerializeField] [Min(0.1f)] float _minSpeedMultiplier = 0.1f;
    [SerializeField] [Min(0.1f)] private float _maxSpeedMultiplier = 2f;

    private float HalfWidth => _fallingWidth / 2f;

    private void Awake()
    {
        if (_maxSpeedMultiplier <= _minSpeedMultiplier) throw new
                Exception($"{nameof(_maxSpeedMultiplier)} must be greater then {nameof(_minSpeedMultiplier)}");

        if (_maxFallingDelay <= _minFallingDelay) throw new
                Exception($"{nameof(_maxFallingDelay)} must be greater then {nameof(_minFallingDelay)}");

        Thing.Pickuped += SetVelocity;
        Thing.Spawned += SetVelocity;
    }

    public void SetVelocity(Thing item)
    {
        StartCoroutine(SetVelocityCoroutine(item));
    }

    private IEnumerator SetVelocityCoroutine(Thing item)
    {
        if (item.transform == null) yield break;

        var body = item.Body;
        body.velocity = Vector2.zero;

        var position = transform.position;
        position.x += Random.Range(-HalfWidth, HalfWidth);

        body.transform.position = position;

        var delay = Random.Range(_minFallingDelay, _maxFallingDelay);
        yield return new WaitForSecondsRealtime(delay);

        if (GamePause.IsPaused)
        {
            SetVelocity(item);
            yield break;
        }

        var multiplier = Random.Range(_minSpeedMultiplier, _maxSpeedMultiplier);
        var velocity = Vector2.down * item.FallingSpeed * multiplier;

        body.velocity = velocity;
    }

    private void OnDestroy()
    {
        Thing.Pickuped -= SetVelocity;
        Thing.Spawned -= SetVelocity;
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        var startPosition = transform.position;
        startPosition.x -= HalfWidth;

        var endPosition = transform.position;
        endPosition.x += HalfWidth;

        Gizmos.DrawLine(startPosition, endPosition);
    }
#endif
}