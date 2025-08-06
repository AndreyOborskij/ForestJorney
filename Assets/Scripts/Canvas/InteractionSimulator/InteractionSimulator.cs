using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSimulator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _treatment;
    [SerializeField] private Button _damage;

    private Health _health;
    private Coroutine _coroutineChangeColor;
    private Color _defaultTreatmentColor;
    private Color _defaultDamageColor;
    private float _colorResetTime = 0.5f;

    private void Awake()
    {
        _health = _player.GetComponentInChildren<Health>();
    }

    private void Start()
    {
        _defaultTreatmentColor = _treatment.image.color;
        _defaultDamageColor = _damage.image.color;
    }

    private void OnEnable()
    {
        _health.Damaged += PaintDamage;
        _health.Cured += PaintCure;
    }

    private void OnDisable()
    {
        _health.Damaged -= PaintDamage;
        _health.Cured -= PaintCure;
    }

    private void ChangeColor(Button button, Color tempColor, Color defaultColor)
    {
        button.image.color = tempColor;

        if (_coroutineChangeColor != null)
        {
            StopCoroutine(_coroutineChangeColor);
        }

        _coroutineChangeColor = StartCoroutine(ResetColor(button, defaultColor));
    }

    private void PaintCure()
    {
        ChangeColor(_treatment, Color.green, _defaultTreatmentColor);
    }

    private void PaintDamage()
    {
        ChangeColor(_damage, Color.red, _defaultDamageColor);
    }

    private IEnumerator ResetColor(Button button, Color defaultColor)
    {
        yield return new WaitForSeconds(_colorResetTime);

        button.image.color = defaultColor;

        _coroutineChangeColor = null;
    }
}