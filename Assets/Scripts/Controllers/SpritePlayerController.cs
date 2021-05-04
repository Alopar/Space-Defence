using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePlayerController : MonoBehaviour
{
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            Destroy(gameObject);
        }
    }
}
