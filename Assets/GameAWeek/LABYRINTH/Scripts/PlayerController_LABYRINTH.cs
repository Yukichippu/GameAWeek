using UnityEngine;

public class PlayerController_LABYRINTH : MonoBehaviour
{
    private GameObject field;   //

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            field.transform.rotation = Quaternion.Euler(0, 0, -5);
        }
        if (Input.GetKey(KeyCode.D))
        {
            field.transform.rotation = Quaternion.Euler(0, 0, 5);
        }
    }
}
