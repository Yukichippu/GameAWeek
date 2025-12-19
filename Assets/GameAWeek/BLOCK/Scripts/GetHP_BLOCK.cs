using UnityEngine;

public class GetHP : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Manager_BLOCK.hp--;
    }
}
