using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMover : MonoBehaviour
{
    //構造体定義
    private struct Ladders
    {
        public GameObject ladderObj;    //梯子オブジェクト
        public Vector2 dis;             //距離
    }
    [SerializeField]
    Ladders[] ladder;                   //梯子オブジェクト配列

    Rigidbody2D rb;
    string baseName = "Ladder";
    bool onLadder = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //オブジェクトを配列に格納
        List<Ladders> laddersList = new List<Ladders>();
        int index = 0;
        while(true)
        {
            //オブジェクト名を生成して取得
            string objName = baseName + index;
            GameObject obj = GameObject.Find(objName);

            //オブジェクトが存在しなければ終了
            if (obj == null)
                break;

            //構造体に格納してリストに追加
            Ladders lad = new Ladders();
            lad.ladderObj = obj;
            lad.dis = Vector2.zero;

            //リストに追加
            laddersList.Add(lad);
            index++;
        }
        //リストを配列に変換して格納
        ladder = laddersList.ToArray();
    }

    private void Update()
    {
        //移動
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position += new Vector3(x, 0, 0);

        if (onLadder)
        {
            rb.gravityScale = 0;
            float y = Input.GetAxis("Vertical") * Time.deltaTime;
            transform.Translate(0, y, 0);
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    private void PreVerMove()
    {
        //移動
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position += new Vector3(x, 0, 0);

        //距離取得
        for (int i = 0; i < ladder.Length; i++)
        {
            //オブジェクトが存在しなければスキップ
            if (ladder[i].ladderObj == null) continue;

            //距離計算
            Ladders temp = ladder[i];
            temp.dis = transform.position - ladder[i].ladderObj.transform.position;
            ladder[i] = temp;

            //梯子に近ければ上下移動可能
            if (Mathf.Abs(ladder[i].dis.x) < 0.5f && Mathf.Abs(ladder[i].dis.y) < 2f)
            {
                float y = Input.GetAxis("Vertical") * Time.deltaTime;

                //重力無効化
                rb.gravityScale = 0;
                transform.position += new Vector3(0, y, 0);
            }
            else
            {
                //重力有効化
                rb.gravityScale = 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //爆弾に衝突したらゲームオーバー
        if (coll.gameObject.tag == "Bomb")
        {
            //ゲームオーバー
            SceneManager.LoadScene("Result");
        }
    }

    // ---トリガー判定---
    private void OnTriggerEnter2D(Collider2D coll)
    {
        float playerY = transform.position.y;
        float objectY = coll.transform.position.y;

        //Groundレイヤーに衝突した場合
        if (coll.gameObject.layer == 3)
        {
            //プレイヤーがオブジェクトの下から入った場合
            if (playerY < objectY)
            {
                Physics2D.IgnoreCollision(coll, GetComponent<Collider2D>());
            }
        }

        //Fieldレイヤーに衝突した場合
        if (coll.gameObject.layer == 8)
            onLadder = true;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.layer == 8)
            onLadder = false;
    }

}
