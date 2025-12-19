using UnityEngine;

public class Ball_BLOCK : MonoBehaviour
{
    // 初速は5.0fとする
    [SerializeField] float speed = 5.0f;

    // Rigidbodyにアクセスして変数に保持しておく
    Rigidbody2D myRb;

    void Start()
    {
        // Rigidbodyコンポーネントを取得する
        myRb = GetComponent<Rigidbody2D>();

        // 右上45度に進む
        myRb.linearVelocity = new Vector3(speed, speed, 0f);

    }
}
