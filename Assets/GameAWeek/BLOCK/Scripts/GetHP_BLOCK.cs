using UnityEngine;

public class GetHP : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HIT");
        Manager_BLOCK.hp--;
    }
}
