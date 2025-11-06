using SephirothTools;
using UnityEngine;

public class PlayerController_LABYRINTH : MonoBehaviour
{
    private Camera      cam;    //MainCamera
    private Rigidbody2D rb;     //PlayerのRigidbody2D

    [SerializeField]
    private float   gravityScale    = 10.0f;                    //重力の値(整数)
    private Vector3 gravityDir;                                 //重力の向き
    private float   cameraDis       = -10.0f;                   //カメラの距離
    private float   rot             = 0.5f;                     //回転量

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //現在のカメラの下向きのベクトルを取得
        gravityDir = -cam.transform.up;

        //重力
        rb.AddForce(gravityDir*gravityScale);
    }

    private void Update()
    {
        //プレイヤーに追従
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cameraDis);

        //カメラ回転とプレイヤーの回転
        if (Input.GetKey(KeyCode.A))
        {
            cam.transform.rotation *= Quaternion.Euler(0, 0, rot);
            transform.rotation *= Quaternion.Euler(0, 0, rot + 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cam.transform.rotation *= Quaternion.Euler(0, 0, -rot);
            transform.rotation *= Quaternion.Euler(0, 0, -(rot + 1));
        }
    }
}
