using UnityEngine;

public class PlayerController_LABYRINTH : MonoBehaviour
{
    public GameObject field;    //

    private Camera cam;         //
    private Rigidbody2D rb;     //

    [SerializeField]
    private Vector2 gravityScale = new Vector2(0, -10.0f);      //
    private Vector3 gravityDir;                                 //
    private Vector3 camForward;                                 //
    private Vector3 camRight;                                   //
    private float   cameraDis = -10.0f;                         //カメラの距離

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //重力
        rb.AddForce(gravityDir*gravityScale);
    }

    private void Update()
    {
        //プレイヤーに追従
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cameraDis);

        camForward = cam.transform.forward;
        camRight = cam.transform.right;

        //現在のカメラの下向きのベクトルを取得
        gravityDir = -Vector3.Cross(camRight, camForward).normalized;

        //カメラ回転
        if (Input.GetKey(KeyCode.A))
        {
            cam.transform.rotation *= Quaternion.Euler(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cam.transform.rotation *= Quaternion.Euler(0, 0, -1);
        }
    }
}
