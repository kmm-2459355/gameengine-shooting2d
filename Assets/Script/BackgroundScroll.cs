using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2.0f; //�X�N���[���X�s�[�h
    float time = 0;

    void Update()
    {
        this.time += Time.deltaTime;
       
        if(this.time <= 32)
        //�I�u�W�F�N�g���ړ�
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

        if (transform.position.y < -15)
        {
            transform.position = new Vector3(0,25);
        }
    }
}
