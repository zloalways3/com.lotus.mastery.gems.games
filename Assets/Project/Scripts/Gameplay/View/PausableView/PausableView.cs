using UnityEngine;
using UnityEngine.UI;

public abstract class PausableView : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    public void Show()
    {
        gameObject.SetActive(true);
        GamePause.TryPause();
    }

    private void Awake()
    {
        _exitButton.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        gameObject.SetActive(false);
        GamePause.TryResume();
    }
}