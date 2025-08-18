using TMPro;
using UnityEngine;

public class TextBar : Bar
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void OutputInfo()
    {
        _text.text = $"{Health.CurrentValue} / {Health.MaxValume}";
    }
}
