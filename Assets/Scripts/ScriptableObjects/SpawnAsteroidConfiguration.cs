using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnAsteroidConfiguration", menuName = "Configurations/SpawnAsteroidConfiguration", order = 2)]
public class SpawnAsteroidConfiguration : ScriptableObject
{
    [SerializeField, Range(1, 10), Tooltip("Одновременное количество астеройдов")] private int _maxNumberAsteroids = 1;
    [SerializeField, Tooltip("Скорость спавна астеройдов")] private float _spawnRate = 1;
    [SerializeField, Tooltip("Префаб астеройда")] private GameObject _prefabAsteroid;

    public int GetMaxAsteroids => _maxNumberAsteroids;
    public float GetSpawnRate => _spawnRate;
    public GameObject GetPrefabAsteroid => _prefabAsteroid;
}