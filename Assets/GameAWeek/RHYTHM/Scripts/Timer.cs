using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 0f;                //�^�C�}�[�̎��Ԃ�ۑ�����ϐ�
    private TextMeshProUGUI timerText;      //�o�߂������Ԃ�\������UI�e�L�X�g

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // �^�C�}�[��1�b�o�߂��邲�Ƃɑ���
        timer += Time.deltaTime;

        // UI�Ƀ^�C�}�[�̌o�ߎ��Ԃ�\������
        if (timerText != null)
        {
            timerText.text = "TIME: " + Mathf.FloorToInt(timer).ToString();
        }
    }
}
