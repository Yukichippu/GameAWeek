using UnityEngine;

public class Foods : MonoBehaviour
{
    private float destroyPos = -10f;

    private void Update()
    {
        if(transform.position.y  < destroyPos)
        {
            Destroy(gameObject);
        }
    }
}
