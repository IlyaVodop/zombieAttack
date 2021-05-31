using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour
{
    public static event Action GameOver;
    public static Player3D Instance;

    [SerializeField]
    private Bullet3D _bullet;
    [SerializeField]
    private Transform _shotPoint;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _shotSound;

    private bool _isDead;

    private const float SHOOT_DELAY = 0.1f;
    private const float SHOOT_VOLUME = 0.2f;
    private const float MOUSE_RAYCAST_DISTANCE = 100f;

    void Start()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while (!_isDead)
        {
            Instantiate(_bullet, _shotPoint.position, _shotPoint.rotation);
            _audioSource.PlayOneShot(_shotSound, SHOOT_VOLUME);
            yield return new WaitForSeconds(SHOOT_DELAY);
        }
    }

    void Update()
    {
        if (!_isDead && (Input.GetMouseButton(0) || Input.touchCount > 0))
        {
            Vector3 aim = Input.mousePosition;
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            aim = Input.GetTouch(0).position;
#endif

            Ray aimRay = Camera.main.ScreenPointToRay(aim, Camera.MonoOrStereoscopicEye.Mono);
            Physics.Raycast(aimRay, out RaycastHit hitInfo, MOUSE_RAYCAST_DISTANCE);
            Vector3 flatPoint = new Vector3(hitInfo.point.x, 1, hitInfo.point.z);
            transform.LookAt(flatPoint);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            _shotPoint.LookAt(flatPoint);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Enemy3D>() != null)
        {
            _isDead = true;
            GetComponent<Animator>().SetBool("IsDead", true);
            StopAllCoroutines();
            GameOver?.Invoke();
        }
    }


    #region Singleton

    void Awake()
    {
        Instance = this;
    }

    void OnDestroy()
    {
        Instance = null;
    }

    #endregion

}
