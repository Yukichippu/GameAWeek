using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_MUDA : MonoBehaviour
{
    public GameObject[] prefabObj;          //連打中に出す文字のプレハブ
    public Image gauge;                     //ゲージ
    public static float speed = 1.0f;       //ゲージの減少スピード
    public static int level = 0;            //難易度

    [SerializeField]
    Vector2 maxPos;                         //画面右上の座標
    [SerializeField]
    float addPoint = 0.1f;                  //1回ボタンを押して増加するゲージの量
    bool onGameOver;                        //  ゲームオーバーを許可するかどうか

    void Start()
    {
        gauge.fillAmount = 0;
        speed /= 10;

        onGameOver = false;
    }

    void Update()
    {
        //ゲージ減少
        if(gauge != null && gauge.fillAmount >= 0)
            gauge.fillAmount -= Time.deltaTime*speed;

        //レベルアップ
        if(gauge.fillAmount >= 0.99)
        {
            level++;
            speed += 0.05f;
            onGameOver = false;
            gauge.fillAmount = 0;
        }
        //ゲームオーバー
        if(onGameOver && gauge.fillAmount <= 0)
        {
            SceneManager.LoadScene("Result");
        }

        //連打
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //たまに違うオブジェクトを出すように
            float num = Random.Range(0, 101);
            int ObjNum;

            if (num >= 95)
            {
                ObjNum = 1;
            }
            else
            {
                ObjNum = 0;
            }

            //ゲームオーバーになるのを許可
            onGameOver = true;

            //ゲージ増加
            gauge.fillAmount += addPoint;

            float randX = Random.Range(-maxPos.x, maxPos.x + 1);
            float randY = Random.Range(-maxPos.y, maxPos.y + 1);

            //生成場所ランダムに
            Vector3 genePos = new Vector3(randX, randY, 0);

            //生成
            GameObject cloneObj = Instantiate(prefabObj[ObjNum], genePos, Quaternion.identity);
        }
    }
}
