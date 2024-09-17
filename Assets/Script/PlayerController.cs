using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameObject explosionPrefab = null;
    float time = 0;
    float span = 0.3f;
    float specialspan = 0.05f;
    float specialTime = 0f;
    float delta = 0;
    const float LOAD_WIDTH = 4.5f;
    const float LOAD_HEIGHT = 4.5f;
    const float MOVE_MAX = 1.9f;
    private Vector3 previousPos, currentPos;
    private int hitCount = 0;
    bool isSpecial = false;


    void Update()
    {
        this.time += Time.deltaTime; 
        //�e���o������
        this.delta += Time.deltaTime;
        if (this.delta > this.span && isSpecial==false)
        {
            this.delta = 0;
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        }
       //�K�E�Z
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpecial = true;
        }
        if (isSpecial)
        {
           
            this.specialTime += Time.deltaTime;
            if (this.delta > this.specialspan)
            {
                this.delta = 0;
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            }
 
        }
        if(this.specialTime > 5)
        {
            isSpecial = false;
            this.specialTime = 0;
        }
        //�X���C�v�ɂ��ړ�����
        if (Input.GetMouseButtonDown(0))
        {
            previousPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            if (time >= 32)
            {
                //�X���C�v�ɂ��ړ��������擾
                currentPos = Input.mousePosition;
                float diffx = (currentPos.x - previousPos.x) / Screen.width * LOAD_WIDTH;
                float diffy = (currentPos.y - previousPos.y) / Screen.width * LOAD_HEIGHT;

                //�v���C���[�̈ʒu���X�V
                Vector3 newPosition = transform.position;
                newPosition.x += diffx;
                newPosition.y += diffy;

                // �ړ��͈͂𐧌�����
                newPosition.x = Mathf.Clamp(newPosition.x, -MOVE_MAX, MOVE_MAX);
                newPosition.y = Mathf.Clamp(newPosition.y, -2.6f, 0.7f);

                transform.position = newPosition;

                previousPos = currentPos;
            }
            else
            {
                //�X���C�v�ɂ��ړ��������擾
                currentPos = Input.mousePosition;
                float diffx = (currentPos.x - previousPos.x) / Screen.width * LOAD_WIDTH;

                //�v���C���[�̈ʒu���X�V
                Vector3 newPosition = transform.position;
                newPosition.x += diffx;

                // �ړ��͈͂𐧌�����
                newPosition.x = Mathf.Clamp(newPosition.x, -MOVE_MAX, MOVE_MAX);

                transform.position = newPosition;

                previousPos = currentPos;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            //hitCount++;
            Destroy(collision.gameObject);
            if (hitCount >= 5)
            {
                Destroy(gameObject);
            }
        }
    }
}
