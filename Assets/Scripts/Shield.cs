using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private Animator _animator;    
    private SpriteRenderer _spriteRenderer;

    private ShieldState _state;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetState(ShieldState state)
    {
        _state = state;

        switch (_state)
        {
            case ShieldState.green:                
                break;
            case ShieldState.yellow:                
                _animator.SetTrigger("greenBlink");
                break;
            case ShieldState.red:
                _animator.SetTrigger("yellowBlink");
                break;
            case ShieldState.none:
                _animator.SetTrigger("redBlink");
                _spriteRenderer.enabled = false;                
                break;
        }
    }
}
