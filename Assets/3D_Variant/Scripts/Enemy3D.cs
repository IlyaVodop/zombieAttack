using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy3D : MonoBehaviour
{
    public static event Action<int> OnReward;

    [SerializeField]
    private AudioClip[] _deathSound;
    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private ZombieProperties _properties;

    private Animator _animator;
    private bool _isDead;

    private const float CHANCE_TO_DEAD_FORWARD = 0.5f;
    private const float TIME_TO_DESTROY_CORPSE = 10f;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed", _properties.currentSpeed);
    }

    void Start()
    {
        transform.LookAt(Player3D.Instance.transform);
    }

    void Update()
    {
        if (_isDead)
        {
            return;
        }
        transform.Translate(transform.forward * _properties.currentSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Bullet"))
        {
            DecreaseHP();
        }
    }
    private void DecreaseHP()
    {
        _properties.currentHP--;

        if (_properties.currentHP <= 0)
        {
            Death();
        }

    }

    private void Death()
    {
        if (_isDead)
        {
            return;
        }
        _isDead = true;
        _animator.SetBool("IsForward", Random.value > CHANCE_TO_DEAD_FORWARD);
        _animator.SetBool("IsDead", true);
        _source.PlayOneShot(_deathSound[Random.Range(0, _deathSound.Length)]);
        OnReward?.Invoke(_properties.currentReward);
        Destroy(gameObject, TIME_TO_DESTROY_CORPSE);
    }
}


