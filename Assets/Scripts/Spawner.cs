using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   /* public Transform[] SpawnPoint = new Transform[3];
    public GameObject[] Enemy = new GameObject[3];

    public float Timer = 10;
    public float TimetIEnumerator = 2;
    void Start()
    {
        StartCoroutine(SpawnTimer());

    }

    void Update()
    {
        Timer = Timer - Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = 10;
            TimetIEnumerator = TimetIEnumerator - 0.1f;
        }
        Debug.Log(Timer);
    }

    IEnumerator SpawnTimer()
    {

        while (true)
        {
            int ranEnemy = Random.Range(0, 3);
            int ranSpawnPoint = Random.Range(0, 3);
            yield return new WaitForSeconds(TimetIEnumerator);
            Instantiate(Enemy[ranEnemy], SpawnPoint[ranSpawnPoint].position, Quaternion.identity);
            break;
        }

    }*/
}
