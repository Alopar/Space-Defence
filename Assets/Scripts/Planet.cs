using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private int _MaxHealth = 5;
    [SerializeField] private int _MaxShield = 3;
    private int _currentHealth;
    private int _currentShield;

    private Shield _shield;

    private void Start()
    {
        _currentHealth = _MaxHealth;
        _currentShield = _MaxShield;
        _shield = FindObjectOfType<Shield>();
    }

    public void TakeDamage(int damage)
    {
        if (_currentShield > 0)
        {
            _currentShield -= damage;
            if (_currentShield >= 3)
            {
                _shield.SetState(ShieldState.green);
            }
            else if (_currentShield == 2)
            {
                _shield.SetState(ShieldState.yellow);
            }
            else if (_currentShield == 1)
            {
                _shield.SetState(ShieldState.red);                
            }
            else
            {
                _shield.SetState(ShieldState.none);                
            }
        }
        else
        {
            _currentHealth -= damage;
        }

        if(_currentHealth <= 0)
        {
            Debug.Log("Game Over!");
        }
    }

    public ShieldState GetShieldState()
    {
        ShieldState _state;
        if(_currentShield >= 3)
        {
            _state = ShieldState.green;
        }
        else if (_currentShield == 2)
        {
            _state = ShieldState.yellow;
        }
        else if (_currentShield == 1)
        {
            _state = ShieldState.red;
        }
        else
        {
            _state = ShieldState.none;
        }

        return _state;
    }
}

public enum ShieldState
{
    none,
    red,
    yellow,
    green
}
