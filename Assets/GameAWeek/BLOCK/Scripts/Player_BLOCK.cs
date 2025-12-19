using UnityEngine;

public class Player_BLOCK : MonoBehaviour
{
    // プレーヤーの移動の速さ
    [SerializeField] float speed = 0.2f;

    void Start()
    {
        // フレームレートを60に設定
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        transform.position += new Vector3(x, 0, 0);
    }
}
