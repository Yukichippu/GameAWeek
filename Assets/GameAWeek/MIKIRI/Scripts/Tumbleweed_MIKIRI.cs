using UnityEngine;

public class Tumbleweed_MIKIRI : MonoBehaviour
{
    private new Camera camera;

    private Vector3     myPos;
    private float  myRot;
    private Vector3     startPos;
    private Vector3     leftEdgePixel;
    private Vector3     leftEdgeWorld;

    private float speed = 2.0f;

    private void Start()
    {
        camera = Camera.main;

        // 画面左端のピクセル座標を計算
        leftEdgePixel = new Vector3(camera.pixelRect.x, Screen.height / 2, 0);

        // ピクセル座標をワールド座標に変換
        leftEdgeWorld = camera.ScreenToWorldPoint(leftEdgePixel);

        myPos = transform.position;
        startPos = myPos;
    }

    private void Update()
    {
        //移動
        myPos.x -= Time.deltaTime * speed;
        transform.position = myPos;
        //回転


        //画面端を超えたら最初の位置に戻る
        if (myPos.x < leftEdgeWorld.x)
        {
            transform.localPosition = startPos;
        }
    }
}
