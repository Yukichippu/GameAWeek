using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // タイマーの時間を保存する変数
    public float timer = 0f;

    // 経過した時間を表示するUIテキスト（オプション）
    private TextMeshProUGUI timerText;

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // タイマーが1秒経過するごとに増加
        timer += Time.deltaTime;

        // UIにタイマーの経過時間を表示する
        if (timerText != null)
        {
            timerText.text = "TIME: " + Mathf.FloorToInt(timer).ToString();
        }
    }
}
