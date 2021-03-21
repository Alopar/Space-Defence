using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _shield = 3;
    public GameObject ex;

    public void TakeDamage(int damage)
    {
        if (_shield > 0)
        {
            _shield -= damage;
        }
        else
        {
            _health -= damage;
        }

        if(_health <= 0)
        {
            Debug.Log("Game Over!");
        }
    }
}