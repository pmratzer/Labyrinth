using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _currentHealth;
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private float _damageAmount,_healthAmount;
    [SerializeField] private Transform _healthBarTransform;
    private Camera _camera;
    private void Awake()
    {
        _currentHealth = _maxHealth;
        _camera = Camera.main;
    }
    private void Update()
    {
        _healthBarTransform.rotation = _camera.transform.rotation;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            TakeDamage(_damageAmount);
        }
        else if (collision.CompareTag("Sanity"))
        {
            Heal(_healthAmount);
        }
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        UpdateHealthBar();
    }
    private void TakeDamage(float amount)
    {
        _currentHealth -= amount;   
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        if (_currentHealth == 0 )
        {
            
            _currentHealth = _maxHealth;
        }
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        _healthBarFill.fillAmount = _currentHealth/_maxHealth;
    }
}
