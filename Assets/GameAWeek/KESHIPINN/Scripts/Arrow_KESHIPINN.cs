using UnityEngine;

public class Allow_KESHIPINN : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed = 20f;
    private float defRot = 90f;

    private void Start()
    {
        player = transform.parent.gameObject;
    }

    private void Update()
    {
        //マウスのスクリーン座標→ワールド座標に変換
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        //プレイヤー位置からマウス方向への角度を求める
        Vector3 dir = mouseWorldPos - player.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //現在角度との差分で回転させる
        float deltaAngle = angle - transform.eulerAngles.z;
        transform.RotateAround(player.transform.position, Vector3.forward, deltaAngle+defRot);
    }
}
