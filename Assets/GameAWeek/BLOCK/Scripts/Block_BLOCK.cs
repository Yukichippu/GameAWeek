using UnityEngine;

public class Block_BLOCK : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Manager_BLOCK.score++;
        Destroy(gameObject);
    }
}
