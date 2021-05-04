using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private PlatformConfiguration _configuration;

    private float _direction;
    private int _currentSpeed;
    private Collider2D _collider;
    private Transform _planetPosition;    

    void Awake()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _currentSpeed = _configuration.GetSpeed;
    }

    void Start()
    {   
        _planetPosition = FindObjectOfType<Planet>().GetComponent<Transform>();
        _direction = Vector3.Angle(_planetPosition.position, transform.position) * Mathf.Deg2Rad;

        UiGameManager.OnMovingButton += Moving;
    }
    
    void Update()
    {
        CheckCollisionOnAsteroid();
    }

    public void Moving(int side)
    {
        _direction += _currentSpeed * side * Time.deltaTime;

        float _x = _planetPosition.position.x + Mathf.Cos(_direction);
        float _y = _planetPosition.position.y + Mathf.Sin(_direction);

        transform.position = new Vector3(_x, _y, 0) * 3.2f;
        transform.eulerAngles = new Vector3(0, 0, (_direction * Mathf.Rad2Deg) - 90);
    }

    private void CheckCollisionOnAsteroid()
    {
        List<Collider2D> _AsteroidColliders = new List<Collider2D>();
        Physics2D.OverlapCollider(_collider, new ContactFilter2D().NoFilter(), _AsteroidColliders);

        foreach (Collider2D collider in _AsteroidColliders)
        {
            GameManager.SetScore(1);
            Destroy(collider.gameObject);
        }
    }

    private void OnDestroy()
    {
        UiGameManager.OnMovingButton -= Moving;
    }
}
