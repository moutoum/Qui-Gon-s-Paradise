using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        if (_slider.maxValue != health.maxHealth)
        {
            _slider.maxValue = health.maxHealth;
        }

        _slider.value = health.currentHealth;
    }
}
