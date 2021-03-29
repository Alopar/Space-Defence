using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoroid : MonoBehaviour
{
    [HideInInspector] public float moveSpeed;
    [HideInInspector] public float rotateSpeed;
    [HideInInspector] public Vector3 targetPoint;

    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _flash;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        transform.eulerAngles += new Vector3(0, 0, (rotateSpeed * Time.deltaTime * Mathf.Rad2Deg));

        if(transform.position == targetPoint)
        {
            Planet _planet = FindObjectOfType<Planet>();
            GameObject _effect = null;            
            Animator _effectAnimator;

            switch (_planet.GetShieldState())
            {
                case ShieldState.green:
                    _effect = Instantiate(_flash);
                    _effectAnimator = _effect.GetComponent<Animator>();
                    _effectAnimator.SetBool("green", true);
                    break;
                case ShieldState.yellow:
                    _effect = Instantiate(_flash);
                    _effectAnimator = _effect.GetComponent<Animator>();
                    _effectAnimator.SetBool("yellow", true);                    
                    break;
                case ShieldState.red:
                    _effect = Instantiate(_flash);
                    _effectAnimator = _effect.GetComponent<Animator>();
                    _effectAnimator.SetBool("red", true);                    
                    break;
                case ShieldState.none:
                    _effect = Instantiate(_explosion);
                    break;
            }
            _effect.transform.position = transform.position;

            _planet.TakeDamage(1);
            Destroy(gameObject);          
        }
    }
}
