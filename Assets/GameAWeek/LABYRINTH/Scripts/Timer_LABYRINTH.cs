using TMPro;
using UnityEngine;

public class Timer_LABYRINTH : MonoBehaviour
{
    private TextMeshProUGUI timerText;  //タイマーを表示するText

    private float   time;       //時間
    private int     s;          //分
    private int     m;          //秒
    private bool    isRunning;  //メインゲーム中かどうか

    public static float finalTime = 0;  //最終タイムを保存する変数

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();

        time = 0;
        isRunning = true;
    }

    private void Update()
    {
        //時間計測
        if (isRunning)
            time += Time.deltaTime;

        //分秒に変換して表示
        s = (int)(time % 60);
        m = (int)(time / 60);

        //60秒になったら0に戻す
        if (s >= 60)
        {
            s = 0;
        }

        //タイマー表示
        timerText.text = string.Format("{0:00}:{1:00}", m, s);
    }

    /// <summary>
    /// ゲーム終了時にタイマーを止める
    /// </summary>
    public void StopTimer()
    {
        isRunning = false;
        finalTime = time;
    }
}
