using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleDirector : MonoBehaviour
{
    public AudioClip touchSound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // �N���b�N�����u�Ԃɔ���
        {
            StartCoroutine(OnTouch());
        }
    }

    private IEnumerator OnTouch()
    {
        // ����炷
        AudioSource.PlayClipAtPoint(touchSound, transform.position);
    
        // ���̍Đ����Ԃ�҂�
        yield return new WaitForSeconds(touchSound.length);
    
        // �V�[����J��
        SceneManager.LoadScene("GameScene");
    }
}