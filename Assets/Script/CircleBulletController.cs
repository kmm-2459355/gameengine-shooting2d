using UnityEngine;
using UnityEngine.UIElements;

public class CircleBulletController : MonoBehaviour
{
    float delta = 0;
    float xspeed = 0f;
    float yspeed = 0f;
    private bool movingRight = true;
    private Vector3 startPosition;
    int hitCount = 0;
    void Start()
    {
        //初期位置を保存
        startPosition = transform.position;
        if(transform.position.x < 0)
        {
            movingRight = false;
        }
        this.xspeed = Random.Range(1.5f, 4f);
        this.yspeed = Random.Range(1.5f, 4f);
    }
    void Update()
    {
        
        //現在の位置を取得
        Vector3 position = transform.position;

        
        if (movingRight)
        {
            //movingRightがtrueの場合は右に進む
            position.x += xspeed * Time.deltaTime;
            position.y -= yspeed * Time.deltaTime;
            if (position.x >= 2)
            {
                movingRight = false;
            }
        }
        else
        {
            //movingRightがfalseの場合は左に進む
            position.x -= xspeed * Time.deltaTime;
            position.y -= yspeed * Time.deltaTime;
            if (position.x <= -2)
            {
                movingRight = true;
            }
        }
        //位置を更新
        transform.position = position;
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

}
