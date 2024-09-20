using UnityEngine;

public class UIEffect : MonoBehaviour
{
    public GameObject effectPrefab;
    GameObject spGauge;
    Vector3 effectPosition = new Vector3(-1, -4.3f, 0);
    private bool effectTriggered = false; // エフェクトが発動したかどうかのフラグ

    void Start()
    {
        this.spGauge = GameObject.Find("SPButton");
    }

    // Update is called once per frame
    void Update()
    {
        // ゲージが満タンかつエフェクトがまだ発動していない場合
        if (spGauge.GetComponent<UnityEngine.UI.Image>().fillAmount == 1 && !effectTriggered)
        {
            Instantiate(effectPrefab, effectPosition, Quaternion.identity);
            effectTriggered = true;
        }
        else if (spGauge.GetComponent<UnityEngine.UI.Image>().fillAmount < 1)
        {
            effectTriggered = false; // ゲージが満タンでなくなったらフラグをリセット
        }
    }
}
