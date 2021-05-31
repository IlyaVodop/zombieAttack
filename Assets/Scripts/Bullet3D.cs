using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3D : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _bulletForce = 100;

    private const float TIME_TO_DESTROY_BULLET = 1f;
    void Start()
    {
        _rigidbody.AddForce(transform.forward * _bulletForce);
        Destroy(gameObject, TIME_TO_DESTROY_BULLET);
    }

}
