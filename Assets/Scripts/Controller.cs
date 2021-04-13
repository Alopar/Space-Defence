using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private static int _score;
    private Platform _platform;

    public static event Action<int> OnSetScore;

    void Start()
    {
        _score = 0;
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

    public static int GetScore()
    {
        return _score;
    }

    public static void SetScore(int value)
    {
        _score += value;
        OnSetScore?.Invoke(_score);
    }
}