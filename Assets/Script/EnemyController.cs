using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject EnemyBulletPrefab;
    public GameObject explosionPrefab = null;
    public AudioClip explosionSound;
    public int hp = 0;
    public float span = 2.5f;
    float delta = 0;
    public float xspeed = 1.0f;
    public float yspeed = 3f;
    public float bulletSpeed = -0.1f;
    float downspeed = 2f;
    private bool movingRight = false;
    private bool movingUp = false;
    private Vector3 startPosition;
    int hitCount = 0;
    void Start()
    {
        //初期位置を保存
        startPosition = transform.position;
        //動き出す方向をランダムにする
        int a = Random.Range(0, 2);
        if (a == 0)
        {
            movingRight = true;
        }
        
    }
    void Update()
    {
        //弾を撃つ
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject bullet = Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<EnemyBulletController>().Initialize(bulletSpeed);
        }

        //現在の位置を取得
        Vector3 position = transform.position;
        if (position.y >= 4.6)
        {
            position.y -= downspeed * Time.deltaTime;
        }
        else 
        {
            if (movingUp)
            {
                //movingUpがtrueの場合は上に進む
                position.y += yspeed * Time.deltaTime;
                if (position.y >= 4.6)
                {
                    movingUp = false;
                }
            }
            else
            {
                //movingUpがfalseの場合は下に進む
                position.y -= yspeed * Time.deltaTime;
                if (position.y <= 0)
                {
                    movingUp = true;
                }
            }

            if (movingRight)
            {
                //movingRightがtrueの場合は右に進む
                position.x += xspeed * Time.deltaTime;
                if (position.x >= 2)
                {
                    movingRight = false;
                }
            }
            else
            {
                //movingRightがfalseの場合は左に進む
                position.x -= xspeed * Time.deltaTime;
                if (position.x <= -2)
                {
                    movingRight = true;
                }
            }
        }
        //位置を更新
        transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hitCount++;
            Destroy(collision.gameObject);

            if (hitCount == hp)
            {
                AudioSource.PlayClipAtPoint(explosionSound , transform.position);
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}