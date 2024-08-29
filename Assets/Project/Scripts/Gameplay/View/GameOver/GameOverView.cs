using UnityEngine;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void Awake()
    {
        DangerThing.Collected += Enable;
    }

    private void Enable()
    {
        _panel.SetActive(true);
    }

    private void OnDestroy()
    {
        DangerThing.Collected -= Enable;
    }
}