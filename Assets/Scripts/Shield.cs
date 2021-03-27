using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private Animator _animator;
    private Coroutine _animationCoroutine;
    private SpriteRenderer _spriteRenderer;
    private Sprite[] _shieldSprites = new Sprite[3];

    private ShieldState _state;    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _shieldSprites[0] = Resources.Load<Sprite>("Sprites/ShieldG");
        _shieldSprites[1] = Resources.Load<Sprite>("Sprites/ShieldO");
        _shieldSprites[2] = Resources.Load<Sprite>("Sprites/ShieldR");
    }

    public void SetState(ShieldState state)
    {
        _state = state;

        switch (_state)
        {
            case ShieldState.yellow:
                _animator.SetBool("green", true);
                _animationCoroutine = StartCoroutine(ChangeShield());
                break;
        }
    }

    private IEnumerator ChangeShield()
    {
        while (true)
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("End"))
            {
                switch (_state)
                {
                    case ShieldState.yellow:
                        _spriteRenderer.sprite = _shieldSprites[1];
                        StopCoroutine(_animationCoroutine);
                        break;
                }
            }
            yield return null;
        }
    }
}
