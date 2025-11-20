using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_KESHIPINN : MonoBehaviour
{
    private enum Turn
    {
        PLAYER_A,   //プレイヤーA(のターン)
        PLAYER_B,   //プレイヤーB
    }
    [SerializeField]
    private Turn turn;

    [SerializeField, Header("Objects")]
    private GameObject[]    players;            //
    [SerializeField]
    private GameObject[]    arrow;              //
    [SerializeField]
    private float           height;             //
    [SerializeField]
    private float           width;              //
    private Image           gauge;              //
    private Rigidbody2D     rb;                 //
    private Canvas          ruleCanvas;         //

    private float           addSpeed = 8.0f;    //
    private bool            setPower;           //
    private bool            isStop;             //


    private void Start()
    {
        arrow[0] = players[0].transform.GetChild(0).gameObject;
        arrow[1] = players[1].transform.GetChild(0).gameObject;
        ruleCanvas = GameObject.Find("RuleCanvas").GetComponent<Canvas>();
        gauge = GameObject.Find("Gauge").GetComponent<Image>();

        ruleCanvas.enabled = false;
        turn = Turn.PLAYER_A;
        setPower = true;
        isStop = false;
    }

    private void Update()
    {
        //死亡時Destroy()されたらシーン切り替え
        if (players[0] == null || players[1] == null)
        {
            SceneManager.LoadScene("Result");
        }
        else
        {
            //ルール表示
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(ruleCanvas.enabled)
                {
                    Time.timeScale = 1f;
                    ruleCanvas.enabled = false;
                }
                else
                {
                    Time.timeScale = 0f;
                    ruleCanvas.enabled = true;
                }
            }

            //範囲外に出たらDestroy()
            if (players[0].transform.position.x > width || players[0].transform.position.x < -width ||
                players[0].transform.position.y > height || players[0].transform.position.y < -height)
            {
                Destroy(players[0]);
            }
            if (players[1].transform.position.x > width || players[1].transform.position.x < -width ||
                players[1].transform.position.y > height || players[1].transform.position.y < -height)
            {
                Destroy(players[1]);
            }

            //プレイヤーごとの行動
            switch (turn)
            {
                case Turn.PLAYER_A:
                    arrow[0].SetActive(true);
                    arrow[1].SetActive(false);
                    //①  
                    if (!isStop)
                    {
                        Debug.Log("Call CorA");
                        //一度だけ呼ばれるように
                        isStop = true;
                        StartCoroutine(SetPower());
                    }
                    //②
                    Flip(players[0], arrow[0]);
                    break;
                case Turn.PLAYER_B:
                    arrow[0].SetActive(false);
                    arrow[1].SetActive(true);
                    //③
                    if (!isStop)
                    {
                        Debug.Log("Call CorB");
                        isStop = true;
                        StartCoroutine(SetPower());
                    }
                    //④
                    Flip(players[1], arrow[1]);
                    break;
            }
        }
    }

    /// <summary>
    /// 弾かれるように移動する
    /// </summary>
    /// <param name="playerObj">プレイヤー</param>
    /// <param name="arrowObj">方向を指定するオブジェクト</param>
    private void Flip(GameObject playerObj, GameObject arrowObj)
    {
        rb = playerObj.GetComponent<Rigidbody2D>();

        //指定オブジェクトのrotation.zをラジアンに変換
        float angleRad = (arrowObj.transform.eulerAngles.z - 90f) * Mathf.Deg2Rad;

        //その方向に向かう正規化ベクトル
        Vector2 dir = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)).normalized;

        //ゲージ(0〜1)に応じて速度が変化
        float speed = addSpeed * gauge.fillAmount;

        if (Input.GetMouseButtonDown(0))
        {
            //弾かれるように移動
            rb.linearVelocity = dir * speed;

            //ターン切り替え
            turn = (turn == Turn.PLAYER_A) ? Turn.PLAYER_B : Turn.PLAYER_A;

            //SetPower()のためのフラグを初期化
            isStop = false;
            setPower = true;
        }
    }

    private IEnumerator SetPower()
    {
        float max = 1.0f;
        float min = 0f;

        //ゲージ操作
        while (setPower)
        {
            //ストップ
            if (Input.GetMouseButtonDown(1))
            {
                setPower = false;
            }

            //上限に達したときに0に戻す
            if (gauge.fillAmount >= max) gauge.fillAmount = min;

            //増加
            gauge.fillAmount += Time.deltaTime;

            yield return null;
        }
        yield return null;
    }
}
