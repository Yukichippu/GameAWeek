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
    private GameObject[] players;
    [SerializeField]
    private GameObject[] arrow;
    [SerializeField]
    private float height;
    [SerializeField]
    private float width;
    private Image gauge;

    private float addSpeed = 100.0f;
    private bool setPower;
    private bool isStop;

    private void Start()
    {
        arrow[0] = players[0].transform.GetChild(0).gameObject;
        arrow[1] = players[1].transform.GetChild(0).gameObject;
        gauge = GameObject.Find("Gauge").GetComponent<Image>();

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
        //指定オブジェクトのrotation.zをラジアンに変換
        float angleRad = (arrowObj.transform.eulerAngles.z - 90) * Mathf.Deg2Rad;

        //その方向に向かう正規化ベクトル
        Vector3 dir = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0f);

        //ゲージ(0〜1)に応じて速度が変化
        float speed = addSpeed * gauge.fillAmount;

        if (Input.GetMouseButtonDown(0))
        {
            //はじかれるように移動
            playerObj.transform.position += dir * speed * Time.deltaTime;

            //動かすオブジェクトを変更するタイミング
            if(turn == Turn.PLAYER_A)
            {
                turn = Turn.PLAYER_B;
            }
            else
            {
                turn = Turn.PLAYER_A;
            }

            //ゲージのフラグ初期化
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
