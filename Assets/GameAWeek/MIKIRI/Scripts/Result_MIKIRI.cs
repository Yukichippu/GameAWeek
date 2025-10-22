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
        // マウス位置をワールド座標に変換
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Raycast を飛ばす（方向はゼロベクトル＝点で当たりを取る）
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

        // レイが何かに当たったら
        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
        
            if (hitObject.CompareTag("Button1"))
            {
                explanationText.text = ("同じ難易度で続けます");
            }
            else if (hitObject.CompareTag("Button2"))
            {
                explanationText.text = ("少し難易度が上がった状態で始めます(未実装)");
            }
            else if (hitObject.CompareTag("Button3"))
            {
                explanationText.text = ("タイトルに戻ります");
            }
            
        }
    }
}
