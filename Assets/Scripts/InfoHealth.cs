using UnityEngine;
using UnityEngine.UI;

public class InfoHealth : MonoBehaviour 
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Transform _position;

    private void Update()
    {
        _slider.transform.position = _position.position;
    }
}