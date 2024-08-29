using UnityEngine;
using UnityEngine.UI;

public class PrivacyPolicyAcceptView : MonoBehaviour
{
    private const string OpenedSaveKey = "PrivacyPolicyOpened";

    [SerializeField] private Button _acceptButton;

    private void Awake()
    {
        _acceptButton.onClick.AddListener(Exit);

        if (PlayerPrefs.HasKey(OpenedSaveKey)) Exit();
    }

    private void Exit()
    {
        Destroy(gameObject);
        PlayerPrefs.SetInt(OpenedSaveKey, default);
    }
}