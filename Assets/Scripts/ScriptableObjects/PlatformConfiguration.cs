using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlatformConfiguration", menuName = "Configurations/PlatformConfiguration", order = 1)]
public class PlatformConfiguration : ScriptableObject
{
    [SerializeField, Range(1, 100), Tooltip("Скорость движения платформы")] private int _speed = 5;

    public int GetSpeed => _speed;
}
