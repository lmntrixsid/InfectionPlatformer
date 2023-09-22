using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "ScriptableObjects/Health", order = 1)]
public class Health : ScriptableObject
{
    public delegate void HealthDelegate(float CurrentHealth);
    public event HealthDelegate onHealthChanged;
    public float maxHealth;
    private float _currentHealth;

    public float health
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = value;
            onHealthChanged?.Invoke(value);
        }
    }

    public void InitializeHealth()
    {
        _currentHealth = maxHealth;
        if (onHealthChanged == null)
        {
            onHealthChanged += (float health) => { /* Do nothing */ };
        }
    }
}