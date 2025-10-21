using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_MIKIRI : MonoBehaviour
{
    private GameObject pObj;
    private GameObject eObj;
    private Image exclamationMark;  //ビックリマークの画像

    [SerializeField]
    private float flame;                //経過時間を格納する変数
    private bool stop;                  //止めたかどうかのフラグ
    private float timeStart = 0.0f;
    private float timePlay  = 0.0f;
    private float waitTime  = 3.0f;     //開始までの待ち時間
    private float randNum;              //ランダムで決まる制限時間
    private float randMin   = 1.0f;    //randNumの最小値
    private float randMax   = 5.0f;    //randNumの最大値

    private void Start()
    {
        exclamationMark = GameObject.Find("exclamation").GetComponent<Image>();

        exclamationMark.enabled = false;
        stop = false;

        randNum = Random.Range(randMin, randMax);
        Debug.Log("randnum: " + randNum);
    }

    private void Update()
    {
        //1.ランダムで押さないといけない範囲を設定
        //2.3秒待ってから開始
        //3.flame変数の中身が範囲内ならクリア

        //3秒待つ
        Debug.Log(IsStart());
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
            Debug.Log("-----------------Play!-----------------");
        }



        ////仮
        //if (!stop)
        //    flame += Time.deltaTime;

        //if(Input.GetKey(KeyCode.Space) && !stop)
        //{
        //    flame *= 100;
        //    flame = (int)flame;
        //    //Debug.Log("Stop: " + flame);
        //    stop = true;
        //}

        //if(stop && flame <= randNum)
        //{
        //    Debug.Log("---CLEAR---,FLAME: " + flame);
        //}
        //else if(stop && flame >= randNum)
        //{
        //    Debug.Log("---DEFEAT---,FLAME: " + flame);
        //}
    }
    
    private bool IsStart()
    {
        timeStart += Time.deltaTime;   
        if (timeStart >= waitTime)
        {
            return true;
        }

        return false;
    }

    private bool IsPlay()
    {
        timePlay += Time.deltaTime;
        if (timePlay >= randNum)
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
