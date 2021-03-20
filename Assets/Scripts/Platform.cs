using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Planet _planet;
    [SerializeField, Range(1, 100)] private int _speed = 5;

    private Transform _planetPosition;
    public float _direction = 0;

    void Start()
    {
        _planetPosition = _planet.GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _direction += _speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _direction -= _speed * Time.deltaTime;
        }

        float _x = _planetPosition.position.x + Mathf.Cos(_direction);
        float _y = _planetPosition.position.y + Mathf.Sin(_direction);

        transform.position = new Vector3(_x, _y, 0) * 3.2f;
        transform.eulerAngles = new Vector3(0, 0, (_direction * Mathf.Rad2Deg) - 90);
    }
}
