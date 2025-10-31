using UnityEngine;

public class Mover : MonoBehaviour
{
    private float       speed       = 0f;                   //移動スピード
    [SerializeField] 
    private Vector3     direction   = Vector3.right;        //移動方向（右方向）

    public void SetSpeed(float newSpeed)
    {
        //他コードからスピードの値を受け取る
        speed = newSpeed;
    }

    void Update()
    {
        //移動
        transform.position += direction * speed * Time.deltaTime;
    }
}
