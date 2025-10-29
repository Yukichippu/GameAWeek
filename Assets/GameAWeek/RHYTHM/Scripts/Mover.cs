using UnityEngine;

public class Mover : MonoBehaviour
{
    private float speed = 0f;
    [SerializeField] private Vector3 direction = Vector3.right; // ˆÚ“®•ûŒüi‰E•ûŒüj

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
