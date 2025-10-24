using UnityEngine;

public class Tumbleweed_MIKIRI : MonoBehaviour
{
    private new Camera camera;                  //MainCamera

    private Vector3     myPos;                  //Position
    private Quaternion  myRot;                  //Rotation
    private Vector3     startPos;               //開始地点
    private Vector3     leftEdgePixel;          //画面左端のピクセル座標
    private Vector3     leftEdgeWorld;          //画面の左端のワールド座標

    private float       delay;                  //次に動くまでの時間
    private float       radomMin = 1.0f;        //delayの最小値
    private float       radomMax = 5.0f;        //delayの最大値
    private float       timer;                  //タイマー
    private float       speed = 2.0f;           //移動速度

    private bool        moving;                 //動いているがどうか

    private void Start()
    {
        camera = Camera.main;

        // 画面左端のピクセル座標を計算
        leftEdgePixel = new Vector3(camera.pixelRect.x, Screen.height / 2, 0);

        // ピクセル座標をワールド座標に変換
        leftEdgeWorld = camera.ScreenToWorldPoint(leftEdgePixel);

        myPos = transform.position;
        myRot = transform.rotation;
        startPos = myPos;

        delay = Random.Range(radomMin,radomMax);
    }

    private void Update()
    {
        if (!moving)
            timer += Time.deltaTime;

        if (timer >= delay)
        {
            moving = true;
            //移動
            myPos.x -= Time.deltaTime * speed;
            transform.position = myPos;
            //回転
            myRot = Quaternion.Euler(0, 0, 0.5f);
            transform.rotation *= myRot;
        }

        //画面左端を超えたら最初の位置に戻る
        if (myPos.x < leftEdgeWorld.x)
        {
            myPos = startPos;
            transform.position = myPos;

            timer = 0f;
            delay = Random.Range(radomMin, radomMax);
            moving = false;
        }

    }
}
