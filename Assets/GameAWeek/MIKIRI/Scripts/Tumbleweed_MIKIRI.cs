using System.Timers;
using UnityEngine;

public class Tumbleweed_MIKIRI : MonoBehaviour
{
    private new Camera camera;

    private Vector3     myPos;
    private Quaternion  myRot;
    private Vector3     startPos;
    private Vector3     leftEdgePixel;
    private Vector3     leftEdgeWorld;

    private float delay;
    private float radomMin = 1.0f;
    private float radomMax = 5.0f;
    private float timer;
    private float speed = 2.0f;

    private bool moving;

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
