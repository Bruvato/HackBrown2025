using NaughtyAttributes;
using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IHasProgress
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth;


    public event EventHandler<OnHealthChangedEventArgs> OnHealthChanged;
    public class OnHealthChangedEventArgs : EventArgs
    {
        public float currentHealth;
        public float maxHealth;
    }

    public event EventHandler OnDeath;

    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;



    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public Boolean IsDead()
    {
        return _currentHealth <= 0;
    }

    public void Damage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        _currentHealth = Mathf.Max(_currentHealth, 0);

        OnHealthChanged?.Invoke(this, new OnHealthChangedEventArgs
        {
            currentHealth = _currentHealth,
            maxHealth = _maxHealth
        });

        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
        {
            progressRatio = _currentHealth / _maxHealth
        });

        if (IsDead())
        {
            Die();
        }
    }


    public void Heal(float healAmount)
    {
        _currentHealth += healAmount;
        _currentHealth = Mathf.Min(_currentHealth, _maxHealth);

        OnHealthChanged?.Invoke(this, new OnHealthChangedEventArgs
        {
            currentHealth = _currentHealth,
            maxHealth = _maxHealth
        });

        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
        {
            progressRatio = _currentHealth / _maxHealth
        });
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died!");

        OnDeath?.Invoke(this, EventArgs.Empty);

        // Implement death logic (e.g., animations, game over screen, respawn)
    }
}
