using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class GameManager_KESHIPINN : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players;
    private GameObject field;
    private GameObject arrow;
    private Image gauge;

    private float maxSpeed = 1.0f;

    private void Start()
    {
        arrow = players[0].transform.GetChild(0).gameObject;
        gauge = GameObject.Find("Gauge").GetComponent<Image>();
    }

    private void Update()
    {
        //指定オブジェクトのrotation.zをラジアンに変換
        float angleRad = arrow.transform.eulerAngles.z * Mathf.Deg2Rad;

        //その方向に向かう正規化ベクトル
        Vector3 dir = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad)+45, 0f);

        //ゲージ(0〜1)に応じて速度が変化
        float speed = maxSpeed * gauge.fillAmount;

        if (Input.GetKey(KeyCode.K))
        {
            //はじかれるように移動
            players[0].transform.position += dir * speed * Time.deltaTime;
        }
    }
}
