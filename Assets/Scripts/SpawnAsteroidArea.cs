using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroidArea : MonoBehaviour
{
    [SerializeField] private SpawnAsteroidConfiguration _configurations;

    private Transform _targetPlanet;
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

    void Start()
    {
        _targetPlanet = FindObjectOfType<Planet>().transform;
    }

    void Update()
    {
        Asteroid[] _meteoroids = FindObjectsOfType<Asteroid>();
        if (_spawnReady && _meteoroids.Length < _configurations.GetMaxAsteroids)
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

        GameObject meteoroid = Instantiate(_configurations.GetPrefabAsteroid);
        meteoroid.transform.position = new Vector3(_x, _y, 0);
        Asteroid _meteoroid = meteoroid.GetComponent<Asteroid>();        

        Vector2 _randomPoint = Random.insideUnitCircle * 2f;
        _meteoroid.targetPoint = _targetPlanet.position + (new Vector3(_randomPoint.x, _randomPoint.y, 0));
        _meteoroid.rotateSpeed = 3;
        _meteoroid.moveSpeed = 3;

        SpriteRenderer _asteroidSpriteRenderer = meteoroid.GetComponent<SpriteRenderer>();
        _asteroidSpriteRenderer.sprite = _asteroidSprites[(int)Random.Range(0, _asteroidSprites.Length)];
    }

    private IEnumerator SpawnTimer()
    {
        float spawnTime = _configurations.GetSpawnRate;

        while (spawnTime > 0)
        {
            spawnTime -= 1 * Time.deltaTime;
            yield return null;
        }

        _spawnReady = true;
    }
}
