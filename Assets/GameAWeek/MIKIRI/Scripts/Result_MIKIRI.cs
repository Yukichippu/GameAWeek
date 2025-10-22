using UnityEngine;
using UnityEngine.UI;

public class Result_MIKIRI : MonoBehaviour
{
    private Text explanationText;

    private void Start()
    {
        explanationText = GameObject.Find("ExplanationText").GetComponent<Text>();
    }

    void Update()
    {
        // �}�E�X�ʒu�����[���h���W�ɕϊ�
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Raycast ���΂��i�����̓[���x�N�g�����_�œ���������j
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

        // ���C�������ɓ���������
        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
        
            if (hitObject.CompareTag("Button1"))
            {
                explanationText.text = ("������Փx�ő����܂�");
            }
            else if (hitObject.CompareTag("Button2"))
            {
                explanationText.text = ("������Փx���オ������ԂŎn�߂܂�(������)");
            }
            else if (hitObject.CompareTag("Button3"))
            {
                explanationText.text = ("�^�C�g���ɖ߂�܂�");
            }
            
        }
    }
}
