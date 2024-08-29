using UnityEngine;

public class AutoResetBalance : MonoBehaviour
{
    private void Awake()
    {
        Balance.Reset();
    }
}