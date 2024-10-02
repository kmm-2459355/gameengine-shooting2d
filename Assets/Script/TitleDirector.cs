using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleDirector : MonoBehaviour
{
    public AudioClip touchSound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // クリックした瞬間に反応
        {
            StartCoroutine(OnTouch());
        }
    }

    private IEnumerator OnTouch()
    {
        // 音を鳴らす
        AudioSource.PlayClipAtPoint(touchSound, transform.position);
    
        // 音の再生時間を待つ
        yield return new WaitForSeconds(touchSound.length);
    
        // シーンを遷移
        SceneManager.LoadScene("GameScene");
    }
}