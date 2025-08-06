using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _textVolume;
    [SerializeField] private Slider _sliderFast;
    [SerializeField] private Slider _sliderSlow;

    private Health _health;
    private int _currentHealth;
    private int _maxHealth;
    private float _rateDecrease = 0.1f;
    private float _percent = 100f;

    private void Awake()
    {
        _health = _player.GetComponentInChildren<Health>();
    }

    private void OnEnable()
    {
        _health.Damaged += ÑhangeVolume;
        _health.Cured += ÑhangeVolume;
    }

    private void Start()
    {
        _currentHealth = _health.CurrentValue;
        _maxHealth = _health.MaxValume;
    }

    private void OnDisable()
    {
        _health.Damaged -= ÑhangeVolume;
        _health.Cured -= ÑhangeVolume;
    }

    private void Update()
    {
        ÑhangeText();
        ÑhangeSliderFast();
        ÑhangeSliderSlow();
    }

    private void ÑhangeVolume()
    {
        _currentHealth = _health.CurrentValue;
    }

    private void ÑhangeText()
    {
        _textVolume.text = $"{_currentHealth}/{_maxHealth}";
    }

    private void ÑhangeSliderFast()
    {
        _sliderFast.value = _currentHealth / _percent;
    }

    private void ÑhangeSliderSlow()
    {
        float targetValue = _currentHealth / _percent;

        _sliderSlow.value = Mathf.MoveTowards(_sliderSlow.value, targetValue, _rateDecrease * Time.deltaTime);
    }
}
