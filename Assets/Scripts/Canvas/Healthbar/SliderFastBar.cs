using UnityEngine;
using UnityEngine.UI;

public class SliderFastBar : Bar
{
    [SerializeField] private Slider _slider;

    protected override void OutputInfo()
    {
        _slider.value = Health.CurrentValue / Health.MaxValume;
    }
}
