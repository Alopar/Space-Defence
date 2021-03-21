using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    [SerializeField, Range(1, 10), Tooltip("Одновременное количество астеройдов")] private int _maxNumberAsteroids = 1;
    [SerializeField] private float _spawnRate = 1;
    [SerializeField] private GameObject _prefabMeteoroid;
    [SerializeField] private Transform _targetPlanet;

    private bool _spawnReady = true;
    private SpriteRenderer _spriteRenderer;
    private Sprite[] _asteroidSprites = new Sprite[3];

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _asteroidSprites[0] = Resources.Load<Sprite>("Sprites/Asteroid1");
        _asteroidSprites[1] = Resources.Load<Sprite>("Sprites/Asteroid2");
        _asteroidSprites[2] = Resources.Load<Sprite>("Sprites/Asteroid3");
    }

    void Update()
    {
        Meteoroid[] _meteoroids = FindObjectsOfType<Meteoroid>();
        if (_spawnReady && _meteoroids.Length < _maxNumberAsteroids)
        {
            _spawnReady = false;

            SpawnMeteoroid();
            StartCoroutine(SpawnTimer());
        }
    }

    private void SpawnMeteoroid()
    {
        float _x = Random.Range(_spriteRenderer.bounds.max.x, _spriteRenderer.bounds.min.x);
        float _y = Random.Range(_spriteRenderer.bounds.max.y, _spriteRenderer.bounds.min.y);

        GameObject meteoroid = Instantiate(_prefabMeteoroid);
        meteoroid.transform.position = new Vector3(_x, _y, 0);
        Meteoroid _meteoroid = meteoroid.GetComponent<Meteoroid>();        

        Vector2 _randomPoint = Random.insideUnitCircle * 2f;
        _meteoroid.targetPoint = _targetPlanet.position + (new Vector3(_randomPoint.x, _randomPoint.y, 0));
        _meteoroid.rotateSpeed = 3;
        _meteoroid.moveSpeed = 3;

        SpriteRenderer _asteroidSpriteRenderer = meteoroid.GetComponent<SpriteRenderer>();
        _asteroidSpriteRenderer.sprite = _asteroidSprites[(int)Random.Range(0, _asteroidSprites.Length)];
    }

    private IEnumerator SpawnTimer()
    {
        float spawnTime = _spawnRate;

        while (spawnTime > 0)
        {
            spawnTime -= 1 * Time.deltaTime;
            yield return null;
        }

        _spawnReady = true;
    }
}
