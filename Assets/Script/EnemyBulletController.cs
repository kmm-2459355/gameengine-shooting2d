using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, -0.01f, 0);

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
