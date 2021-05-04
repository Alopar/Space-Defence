using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnAsteroidConfiguration", menuName = "Configurations/SpawnAsteroidConfiguration", order = 2)]
public class SpawnAsteroidConfiguration : ScriptableObject
{
    [SerializeField, Range(1, 10), Tooltip("������������� ���������� ����������")] private int _maxNumberAsteroids = 1;
    [SerializeField, Tooltip("�������� ������ ����������")] private float _spawnRate = 1;
    [SerializeField, Tooltip("������ ���������")] private GameObject _prefabAsteroid;

    public int GetMaxAsteroids => _maxNumberAsteroids;
    public float GetSpawnRate => _spawnRate;
    public GameObject GetPrefabAsteroid => _prefabAsteroid;
}