using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 0f;                //タイマーの時間を保存する変数
    private TextMeshProUGUI timerText;      //経過した時間を表示するUIテキスト

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
