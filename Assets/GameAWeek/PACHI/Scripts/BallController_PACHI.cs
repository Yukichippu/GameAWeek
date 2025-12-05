using UnityEngine;

public class BallController_PACHI : MonoBehaviour
{
    Vector3 startPos;

    bool isLaunched = false; // ボールが発射されたかどうかのフラグ

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (isLaunched)
        {

        }
        else
        {
            // ボールが発射されていない場合、スタート位置に固定する
            transform.position = startPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isLaunched = true;
    }
}
