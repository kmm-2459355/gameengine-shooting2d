using UnityEngine;

public class BossBulletController: MonoBehaviour
{
    public float speed = 13f;
    private Vector3 targetDirection;
    public void Initialize(Vector3 targetPosition)
    {
        targetDirection = (targetPosition - transform.position).normalized;
    }

    void Update()
    {
        transform.position += targetDirection * speed * Time.deltaTime;
        if (transform.position.y < -5 || transform.position.x > 3 || transform.position.x < -3)
        {
            Destroy(gameObject);
        }
    }

}
