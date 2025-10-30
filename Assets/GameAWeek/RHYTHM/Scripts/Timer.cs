using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // �^�C�}�[�̎��Ԃ�ۑ�����ϐ�
    public float timer = 0f;

    // �o�߂������Ԃ�\������UI�e�L�X�g�i�I�v�V�����j
    private TextMeshProUGUI timerText;

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
