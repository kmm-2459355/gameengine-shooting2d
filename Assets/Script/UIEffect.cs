using UnityEngine;

public class UIEffect : MonoBehaviour
{
    public GameObject effectPrefab;
    GameObject spGauge;
    Vector3 effectPosition = new Vector3(-1, -4.3f, 0);
    private bool effectTriggered = false; // �G�t�F�N�g�������������ǂ����̃t���O

    void Start()
    {
        this.spGauge = GameObject.Find("SPButton");
    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[�W�����^�����G�t�F�N�g���܂��������Ă��Ȃ��ꍇ
        if (spGauge.GetComponent<UnityEngine.UI.Image>().fillAmount == 1 && !effectTriggered)
        {
            Instantiate(effectPrefab, effectPosition, Quaternion.identity);
            effectTriggered = true;
        }
        else if (spGauge.GetComponent<UnityEngine.UI.Image>().fillAmount < 1)
        {
            effectTriggered = false; // �Q�[�W�����^���łȂ��Ȃ�����t���O�����Z�b�g
        }
    }
}
