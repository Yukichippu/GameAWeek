using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_MIKIRI : MonoBehaviour
{
    private Canvas          mainCanvas;     //ゲーム画面のCanvas
    private Canvas          selectUICanvas; //ステージクリア後の選択画面のCanvas
    private AudioSource     myAudioSouce;   //AudioSouce

    private Image           exclamationMark;//ビックリマークの画像
    private Text            evaText;        //評価
    private TextMeshProUGUI frameText;      //フレーム 
    private TextMeshProUGUI stageNumText;   //ステージ数
    [SerializeField]
    private AudioClip       se;             //SE

    public float delay     = 50.0f;         //クリアになるframeの範囲

    [SerializeField]
    private float frame;                    //経過時間を格納する変数
    private bool  stop;                     //止めたかどうかのフラグ
    private bool  playing;                  //ゲーム中か
    private bool  select;                   //ステージクリア後の選択画面かどうか
    private bool  oneShot;                  //SEを一度だけ流すための変数
    private float timeStart = 0.0f;         //IsStartのタイマー       
    private float timePlay  = 0.0f;         //IsPlayのタイマー
    private float timeEnd   = 0.0f;         //IsEndのタイマー
    private float waitTime  = 3.0f;         //開始までの待ち時間
    private float randNum;                  //ランダムで決まる制限時間
    private float randMin   = 1.0f;         //randNumの最小値
    private float randMax   = 5.0f;         //randNumの最大値
    private int   stageNum  = 1;            //ステージ数

    private void Start()
    {
        mainCanvas      = GameObject.Find("Canvas").GetComponent<Canvas>();
        selectUICanvas  = GameObject.Find("SelectUICanvas").GetComponent<Canvas>();
        myAudioSouce    = GetComponent<AudioSource>();

        exclamationMark = GameObject.Find("exclamation").GetComponent<Image>();
        evaText         = GameObject.Find("EvaluationText").GetComponent<Text>();
        frameText       = GameObject.Find("FrameText").GetComponent<TextMeshProUGUI>();
        stageNumText    = GameObject.Find("StageText").GetComponent<TextMeshProUGUI>();

        mainCanvas.enabled = true;
        selectUICanvas.enabled = false;

        exclamationMark.enabled = false;
        stop = false;
        playing = false;
        select = true;

        PlayerPrefs.DeleteKey("stageNumber");

        stageNumText.text = ("Stage:") + stageNum.ToString();
        randNum = Random.Range(randMin, randMax);
    }

    private void Update()
    {
        //待機
        if (!IsStart())
        {            
            return;
        }
        //開始
        if (IsPlay())
        {
            exclamationMark.enabled = true;
            playing = true;
        }
        else
        {
            //びっくりマークが出る前にキーを押した場合タイトルに戻る
            if(Input.GetKey(KeyCode.Space))
            {
                evaText.text = ("お手付き!!");
                
                if (IsEnd())
                {
                    SceneManager.LoadScene("Title");
                }
            }
            return;
        }

        //frameの増加
        if (!stop)
            frame += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && !stop)
        {
            //frame計算
            frame *= 60;
            frame = (int)frame;

            //frameの増加を止める
            stop = true;
        }

        //ステージクリア
        if (stop && frame <= delay)
        {
            //びっくりマークを見えなくする
            exclamationMark.enabled = false;

            //評価とframeのテキストを更新
            frameText.text = frame.ToString();
            evaText.text = ("お見事！");

            if (!oneShot)
            {
                myAudioSouce.PlayOneShot(se);
                oneShot = true;
            }

            //次のステージへ
            if(IsEnd())
            {
                //selectUICanvasの操作開始
                mainCanvas.enabled = false;
                selectUICanvas.enabled = true;

                //selectUICanvasの操作が終わるまで止める
                if (select)
                {
                    //同じ難易度でスタート
                    if (Input.GetKey(KeyCode.Alpha1))
                    {
                        SceneManager.LoadScene("Game");
                    }
                    //難易度を上げてスタート
                    if (Input.GetKey(KeyCode.Alpha2))
                    {
                        select = false;
                    }
                    //タイトルへ
                    if (Input.GetKey(KeyCode.Alpha3))
                    {
                        SceneManager.LoadScene("Title");
                    }
                    return;
                }

                //難易度を上げた場合この下を通る
                mainCanvas.enabled = true;
                selectUICanvas.enabled = false;

                //ステージ数更新
                stageNum++;

                //ステージ数のテキスト更新
                stageNumText.text = ("Stage:") + stageNum.ToString();

                //難易度上昇
                delay -= 5.0f;

                //初期化
                timeEnd = 0;

                PlayerPrefs.SetInt("stageNum", stageNum);

                //ゲーム開始時の状態に戻す
                stop = false;
                playing = false;
                oneShot = false;
                frame = 0;
                evaText.text = ("");
                frameText.text = ("");
                randNum = Random.Range(randMin, randMax);

            }
        }
        //ゲームオーバー
        else if (stop && frame >= delay)
        {
            frameText.text = frame.ToString();
            evaText.text = ("残念...");

            //リザルトに移動
            if (IsEnd())
            {
                SceneManager.LoadScene("Result");
            }
        }
    }
    
    /// <summary>
    /// 開始まで3秒待つ
    /// </summary>
    /// <returns></returns>
    private bool IsStart()
    {
        if (!playing)
        {
            //3秒待つ
            timeStart += Time.deltaTime;
            if (timeStart >= waitTime)
            {
                return true;
            }

            return false;
        }
        else
        {
            timeStart = 0;
            return true;
        }
        
    }

    /// <summary>
    /// ビックリマークを出すまでの時間をランダムで待つ
    /// </summary>
    /// <returns></returns>
    private bool IsPlay()
    {
        if (!playing)
        {
            //ランダムな時間待つ
            timePlay += Time.deltaTime;
            if (timePlay >= randNum)
            {
                return true;
            }

            return false;
        }
        else
        {
            timePlay = 0; 
            return true;
        }
        
    }

    /// <summary>
    /// 終了まで3秒待つ
    /// </summary>
    /// <returns></returns>
    private bool IsEnd()
    {
        //3秒待つ
        timeEnd += Time.deltaTime;
        if (timeEnd >= waitTime)
        {
            return true;
        }

        return false;
    }
}
