using UnityEngine;
using UnityEngine.UIElements;

public class CircleBulletController : MonoBehaviour
{
    float delta = 0;
    public float xspeed = 1.0f;
    public float yspeed = 3f;
    private bool movingRight = true;
    private Vector3 startPosition;
    int hitCount = 0;
    void Start()
    {
        //�����ʒu��ۑ�
        startPosition = transform.position;
        if(transform.position.x < 0)
        {
            movingRight = false;
        }
    }
    void Update()
    {
        
        //���݂̈ʒu���擾
        Vector3 position = transform.position;

        
        if (movingRight)
        {
            //movingRight��true�̏ꍇ�͉E�ɐi��
            position.x += xspeed * Time.deltaTime;
            position.y -= yspeed * Time.deltaTime;
            if (position.x >= 2)
            {
                movingRight = false;
            }
        }
        else
        {
            //movingRight��false�̏ꍇ�͍��ɐi��
            position.x -= xspeed * Time.deltaTime;
            position.y -= yspeed * Time.deltaTime;
            if (position.x <= -2)
            {
                movingRight = true;
            }
        }
        //�ʒu���X�V
        transform.position = position;
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

}
