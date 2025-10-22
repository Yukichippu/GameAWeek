using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_MIKIRI : MonoBehaviour
{
    private Image exclamationMark;      //ビックリマークの画像
    private Text evaText;    //評価
    private TextMeshProUGUI frameText;  //フレーム 

    [SerializeField]
    private float delay     = 20.0f;    //
    [SerializeField]
    private float frame;                //経過時間を格納する変数
    private bool stop;                  //止めたかどうかのフラグ
    private float timeStart = 0.0f;
    private float timePlay  = 0.0f;
    private float timeEnd   = 0.0f;
    private float waitTime  = 3.0f;     //開始までの待ち時間
    private float randNum;              //ランダムで決まる制限時間
    private float randMin   = 1.0f;     //randNumの最小値
    private float randMax   = 5.0f;     //randNumの最大値

    private void Start()
    {
        exclamationMark = GameObject.Find("exclamation").GetComponent<Image>();
        evaText         = GameObject.Find("EvaluationText").GetComponent<Text>();
        frameText       = GameObject.Find("FrameText").GetComponent<TextMeshProUGUI>();

        exclamationMark.enabled = false;
        stop = false;

        randNum = Random.Range(randMin, randMax);
    }

    private void Update()
    {
        //1.ランダムで押さないといけない範囲を設定
        //2.3秒待ってから開始
        //3.flame変数の中身が範囲内ならクリア

        if (!IsStart())
        {            
            Debug.Log("Wait Time...");
            return;
        }
            Debug.Log("----------------Start!----------------");
        //開始
        if (IsPlay())
        {
            exclamationMark.enabled = true;
            Debug.Log("-----------------Play!----------------");
        }
        else
        {
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

        //仮
        if (!stop)
            frame += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && !stop)
        {
            frame *= 60;
            frame = (int)frame;
            stop = true;
        }

        if (stop && frame <= delay)
        {
            exclamationMark.enabled = false;
            frameText.text = frame.ToString();
            evaText.text = ("お見事！");
            Debug.Log("---CLEAR---,FLAME: " + frame);

            if(IsEnd())
            {
                SceneManager.LoadScene("Result");
            }
        }
        else if (stop && frame >= delay)
        {
            frameText.text = frame.ToString();
            evaText.text = ("残念...");
            Debug.Log("---DEFEAT---,FLAME: " + frame);

            if (IsEnd())
            {
                SceneManager.LoadScene("Result");
            }
        }
    }
    
    private bool IsStart()
    {
        //3秒待つ
        timeStart += Time.deltaTime;   
        if (timeStart >= waitTime)
        {
            return true;
        }

        return false;
    }

    private bool IsPlay()
    {
        //ランダムな時間待つ
        timePlay += Time.deltaTime;
        if (timePlay >= randNum)
        {
            return true;
        }

        return false;
    }

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

    private bool NextStage()
    {
        return false;
    }   
}
