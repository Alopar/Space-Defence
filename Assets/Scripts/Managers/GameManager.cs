using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _self;

    private int _score;
    private Platform _platform;

    public static event Action<int> OnSetScore;

    void Awake()
    {
        if (_self == null)
        {
            _self = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        Scene _scene = SceneManager.GetActiveScene();

        switch (_scene.name)
        {
            case "Menu":
                AudioManager.Play("BackgroundMainMenu");
                break;
            case "Game":
                SetScore(0);
                _platform = FindObjectOfType<Platform>();

                AudioManager.Play("BackgroundGame");
                break;
        }
    }

    void Update()
    {
        // only debug
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
        return _self._score;
    }

    public static void SetScore(int value)
    {
        _self._score += value;
        OnSetScore?.Invoke(_self._score);
    }

    [CustomEditor(typeof(GameManager))]
    public class GameManagerEditor : Editor
    {
        private GameManager _target;

        void OnEnable()
        {
            _target = target as GameManager;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(20);
            GUILayout.Label("Score: " + _target._score);

            int _asteroidCount = FindObjectsOfType<Asteroid>().Length;
            GUILayout.Label("Active asteroids: " + _asteroidCount);
        }
    }
}