using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  /*  public float Offset;
    public GameObject Bullet;
    public Transform ShotPoint;

    private float timeBtnShots;
    public float startTimeBtnShots;

    public static Player Instance;

    void Awake()
    {

        Instance = this;
    }

    void OnDerstroy()
    {
        Instance = null;
    }
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + Offset);
        if (timeBtnShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(Bullet, ShotPoint.position, ShotPoint.transform.rotation);
                timeBtnShots = startTimeBtnShots;
            }
        }
        else
        {
            timeBtnShots -= Time.deltaTime;
        }
    }*/
}
