using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _currentHealth;
    [SerializeField] private Image _healthBarFill;
    //game controller for death here
    [SerializeField] private float _damageAmount;
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
        if (collision.CompareTag("obstacle"))
        {
            TakeDamage(20);
        }
    }
    private void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        if (_currentHealth == 0)
        {
            //game controller for death here
            _currentHealth = _maxHealth;
        }
    }
    private void UpdateHealthBar()
    {
        _healthBarFill.fillAmount = _currentHealth / _maxHealth;
    }
}
