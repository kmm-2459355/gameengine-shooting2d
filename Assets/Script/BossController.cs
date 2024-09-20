using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class BossController : MonoBehaviour
{
    public GameObject BossBulletPrefab;
    public GameObject SubBulletPrefab;
    public GameObject CircleBulletPrefab;
    public GameObject explosionPrefab = null;
    public Transform  player;
    float time        = 0;
    float downspeed   = 1f;
    float mainspan    = 0.5f;
    float subspan     = 3f;
    float circlespan  = 5f;
    float maindelta   = 0;
    float subdelta    = 0;
    float circledelta = 0;
    float expdelta = 0;
    float rx = 0;
    float ry = 0;
    public float xspeed =0.5f;
    private bool movingRight = false;
    Vector3 MainBulletPosition = new Vector3(0, 1, 0);
    Vector3 lSubBulletPosition = new Vector3(-1.9f, 4f, 0);
    Vector3 rSubBulletPosition = new Vector3(1.9f, 4f, 0);
    Vector3 lCirclePosition    = new Vector3(-0.75f, 1.7f, 0);
    Vector3 rCirclePosition    = new Vector3(0.75f, 1.7f, 0);
    Vector3 ExplosionPosition1;
    Vector3 ExplosionPosition2;
    private Vector3 targetDirection;
    private Vector3 startPosition;
    public int hp = 0;
    int hitCount  = 0;
    bool isDead = false;

    void Start()
    {
        //初期位置を保存
        startPosition = transform.position;
    }
    void Update()
    {
        if (isDead == false)
        {
            this.time += Time.deltaTime;
            if (time >= 32)
            {
                Vector3 position = transform.position;

                if (position.y >= 3.4)
                {
                    position.y -= downspeed * Time.deltaTime;
                }
                else
                {
                    this.maindelta += Time.deltaTime;
                    if (this.maindelta > this.mainspan)
                    {
                        this.maindelta = 0;
                        mainShoot();
                    }
                    this.subdelta += Time.deltaTime;
                    if (this.subdelta > this.subspan)
                    {
                        this.subdelta = 0;
                        subShoot();
                    }
                    this.circledelta += Time.deltaTime;
                    if (this.circledelta > this.circlespan)
                    {
                        this.circledelta = 0;
                        circleShoot();
                    }
                }
                //位置を更新
                transform.position = position;
            }
        }
        if (isDead)
        {
            this.expdelta += Time.deltaTime;
            if (this.expdelta > 0.05)
            {
                this.expdelta = 0;
                rx = Random.Range(-1.5f, 1.5f);
                ry = Random.Range(2, 5f);
                Vector3 ExplosionPosition = new Vector3(rx, ry, 0);
                Instantiate(explosionPrefab, ExplosionPosition, Quaternion.identity);
            }
            //現在の位置を取得
            Vector3 position = transform.position;
            if (movingRight)
            {
                //movingRightがtrueの場合は右に進む
                position.x += xspeed * Time.deltaTime;
                if (position.x >= 0.01)
                {
                    movingRight = false;
                }
            }
            else
            {
                //movingRightがfalseの場合は左に進む
                position.x -= xspeed * Time.deltaTime;
                if (position.x <= -0.02)
                {
                    movingRight = true;
                }
            }
            //位置を更新
            transform.position = position;
        }
    }
   void mainShoot()
    {
        if (player != null)
        {
            GameObject bullet = Instantiate(BossBulletPrefab, MainBulletPosition, Quaternion.identity);
            BossBulletController bulletScript = bullet.GetComponent<BossBulletController>();
            if (bulletScript != null)
            {
                bulletScript.Initialize(player.position);
            }
        }
    }
    void subShoot()
    {
        if (player != null)
        {
            GameObject bulletl = Instantiate(SubBulletPrefab, lSubBulletPosition, Quaternion.identity);
            GameObject bulletr = Instantiate(SubBulletPrefab, rSubBulletPosition, Quaternion.identity);
            BossBulletController bulletlScript = bulletl.GetComponent<BossBulletController>();
            BossBulletController bulletrScript = bulletr.GetComponent<BossBulletController>();
            if (bulletlScript != null)
            {
                bulletlScript.Initialize(player.position);
            }
            if (bulletrScript != null)
            {
                bulletrScript.Initialize(player.position);
            }
        }
    }
    void circleShoot()
    {
        if (player != null)
        {
            GameObject bulletl = Instantiate(CircleBulletPrefab, lCirclePosition, Quaternion.identity);
            GameObject bulletr = Instantiate(CircleBulletPrefab, rCirclePosition, Quaternion.identity);
            BossBulletController bulletlScript = bulletl.GetComponent<BossBulletController>();
            BossBulletController bulletrScript = bulletr.GetComponent<BossBulletController>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player != null)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                hitCount++;
                Destroy(collision.gameObject);
                if (hitCount >= hp)
                {
                    isDead = true;
                }
            }
        }
    }
}

