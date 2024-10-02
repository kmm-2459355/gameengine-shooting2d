using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject explosionPrefab = null;
    public AudioClip bulletSound;
    public AudioClip damageSound;
    public AudioClip specialSound;
    public AudioClip explosionSound;
    public AudioClip gameoverSound;
    private AudioSource audioSource;
    GameObject hpBar;
    GameObject spGauge;
    float time = 0;
    float span = 0.3f;
    float specialspan = 0.05f;
    float specialTime = 0f;
    float delta = 0;
    const float LOAD_WIDTH = 4.5f;
    const float LOAD_HEIGHT = 4.5f;
    const float MOVE_MAX = 1.9f;
    private Vector3 previousPos, currentPos;
    bool isSpecial = false;
    bool isSpecialSE = true;
    public GameObject GamaOverDialog;
    private AudioSource bgmAudioSource;

    private void Start()
    {
        Application.targetFrameRate = 60;
        this.hpBar = GameObject.Find("HP_Yellow");
        this.spGauge = GameObject.Find("SPButton");
        GamaOverDialog.SetActive(false);
        bgmAudioSource = FindObjectOfType<AudioSource>();
    }
    void Update()
    {
        this.time += Time.deltaTime; 
        //弾を出す処理
        this.delta += Time.deltaTime;
        if (this.delta > this.span && isSpecial==false)
        {
            this.delta = 0;
            AudioSource.PlayClipAtPoint(bulletSound, transform.position);
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        }
       //必殺技
        if (isSpecial)
        {
            this.specialTime += Time.deltaTime;
            if (this.delta > this.specialspan)
            {
                this.delta = 0;
                AudioSource.PlayClipAtPoint(bulletSound, transform.position);
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            }
        }
        if(this.specialTime > 4.5)
        {
            isSpecialSE = true;
            isSpecial = false;
            this.specialTime = 0;
        }
        //スワイプによる移動処理
        if (Input.GetMouseButtonDown(0))
        {
            previousPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
                //スワイプによる移動距離を取得
                currentPos = Input.mousePosition;
                float diffx = (currentPos.x - previousPos.x) / Screen.width * LOAD_WIDTH;
                float diffy = (currentPos.y - previousPos.y) / Screen.width * LOAD_HEIGHT;

                //プレイヤーの位置を更新
                Vector3 newPosition = transform.position;
                newPosition.x += diffx * 1.5f;
                newPosition.y += diffy * 1.5f;

                // 移動範囲を制限する
                newPosition.x = Mathf.Clamp(newPosition.x, -MOVE_MAX, MOVE_MAX);
                newPosition.y = Mathf.Clamp(newPosition.y, -2.6f, 0.7f);

                transform.position = newPosition;

                previousPos = currentPos;
        }
        if (isSpecial == false)
        {
            this.spGauge.GetComponent<UnityEngine.UI.Image>().fillAmount += 0.001f;
        }
        if (spGauge.GetComponent<UnityEngine.UI.Image>().fillAmount == 1&& isSpecialSE)
        {
            AudioSource.PlayClipAtPoint(specialSound, transform.position);
            isSpecialSE = false;
        }
    }
    public void SPButtonDown()
    {
        if (this.spGauge.GetComponent<UnityEngine.UI.Image>().fillAmount == 1)
        {
            isSpecial = true;
            this.spGauge.GetComponent<UnityEngine.UI.Image>().fillAmount -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(damageSound, transform.position);
            this.hpBar.GetComponent<UnityEngine.UI.Image>().fillAmount -= 0.04f;
            if (this.hpBar.GetComponent<UnityEngine.UI.Image>().fillAmount == 0)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
                AudioSource.PlayClipAtPoint(gameoverSound, transform.position);
                Destroy(gameObject);
                GamaOverDialog.SetActive(true);
                
                if (bgmAudioSource != null)
                {
                    bgmAudioSource.Stop();
                }
            }
        }
    }
}
