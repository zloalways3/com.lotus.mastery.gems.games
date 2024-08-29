using UnityEngine;
using UnityEngine.UI;

public class SceneLoadingSliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void UpdateView(float value)
    {
        _slider.value = value;
    }

    private void OnEnable()
    {
        SceneLoading.ProgressUpdated += UpdateView;
    }

    private void OnDisable()
    {
        SceneLoading.ProgressUpdated -= UpdateView;
    }
}