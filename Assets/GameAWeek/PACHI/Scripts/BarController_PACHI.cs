using UnityEngine;

public class BarController_PACHI : MonoBehaviour
{
    [SerializeField, Header("回転軸の位置")]
    Vector3 pivotOffset = Vector3.zero; //軸位置

    float rotSpeed = 60f;               //クリック中の回転速度
    float minAngle = -20f;              //最小角度
    float maxAngle = 90f;               //最大角度
    float springPower = 50f;            //バネの強さ(倍率)
    float currentAngle = 0f;            //現在の角度

    void Update()
    {
        bool isHolding = Input.GetMouseButton(0);

        //pivot の世界座標
        Vector3 pivot = transform.TransformPoint(pivotOffset);
        Debug.Log(pivot);

        if (isHolding)
        {
            //角度増加
            currentAngle += rotSpeed * Time.deltaTime;
        }
        else
        {
            //バネのように戻る力（角度が大きいと強くなる）
            float returnPower = currentAngle * springPower * Time.deltaTime;
            currentAngle -= returnPower;
        }

        //角度を制限(-20〜90)
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

        //回転(pivotを軸にZ回転)
        RotateAroundPivot(pivot, currentAngle);
    }

    void RotateAroundPivot(Vector3 pivot, float angle)
    {
        //pivot基準で回転
        transform.rotation = Quaternion.identity;
        transform.RotateAround(pivot, Vector3.forward, angle);
    }

}
