using UnityEngine;

public class Mover : MonoBehaviour
{
    private float speed = 0f;
    [SerializeField] private Vector3 direction = Vector3.right; // �ړ������i�E�����j

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
