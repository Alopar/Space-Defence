using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Platform _platform;

    void Start()
    {
        _platform = FindObjectOfType<Platform>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _platform.Moving(1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _platform.Moving(-1);
        }
    }
}
