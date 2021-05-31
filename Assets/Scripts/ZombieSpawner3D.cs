using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieSpawner3D : MonoBehaviour
{
    [SerializeField]
    private Transform[] _spawnPoints;

    [SerializeField]
    private Enemy3D _zombieStandard;

    [SerializeField]
    private Enemy3D _zombieFast;

    [SerializeField]
    private Enemy3D _zombieArmored;


    private float _spawnDelay = 2;

    void Awake()
    {
        StartCoroutine(IncreaseDifficult());
        Player3D.GameOver += StopAllCoroutines;
    }

 

    IEnumerator Start()
    {
        while (true)
        {
            var randomZombie = GetMyZombie();
            var randomSpawn = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            Instantiate(randomZombie, randomSpawn.position, randomSpawn.rotation);

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    IEnumerator IncreaseDifficult()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            if (_spawnDelay > 0.5f)
            {
                _spawnDelay -= 0.1f;
            }
            else
            {
                break;
            }
        }
    }


    private Enemy3D GetMyZombie()
    {
        //    ����� - �������.����� �������� 2 ����� � ������� � 10 ��, �� ��� �������� ������ 7 �����.���� ������ -60 %
        //    ����� - �������.����� �������� 3 ����� � ������� � 10 ��, �� ��� �������� ����������� 12 �����.���� ������ -30 %
        //    ������������� �����.����� �������� 1 ���� � ������� � 50 ��, �� ��� �������� ������ 30 �����.���� ������ -10 %


        var random = Random.value;

        if (random <= 0.1f)
        {
            return _zombieArmored;
        }

        if (random > 0.1f && random <= 0.4f)
        {
            return _zombieFast;
        }

        return _zombieStandard;
    }



}
