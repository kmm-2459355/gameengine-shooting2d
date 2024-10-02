using UnityEngine;
using System;

public class EnemyBulletController : MonoBehaviour
{
    public float speed = -0.1f;
    public void Initialize(float bulletSpeed)
    {
        speed = bulletSpeed;
    }
    void Update()
    {
        transform.Translate(0, speed, 0);

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
