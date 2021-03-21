using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoroid : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public Vector3 targetPoint;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        transform.eulerAngles += new Vector3(0, 0, (rotateSpeed * Time.deltaTime * Mathf.Rad2Deg));

        if(transform.position == targetPoint)
        {
            Planet _planet = FindObjectOfType<Planet>();
            _planet.TakeDamage(1);

            GameObject _ex = Instantiate(_planet.ex);
            _ex.transform.position = transform.position;

            Destroy(gameObject);          
        }
    }
}
