using UnityEngine;

public class PlayerController_LABYRINTH : MonoBehaviour
{
    public GameObject field;   //

    [SerializeField]
    private float gravityScale = -10.0f;
    

    private void Update()
    {
        Physics2D.gravity = new Vector2(0,gravityScale);

        

        if (Input.GetKey(KeyCode.A))
        {
            //field.transform.rotation *= Quaternion.Euler(0, 0, -1);
            field.transform.RotateAround(transform.position, Vector3.forward, -1.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //field.transform.rotation *= Quaternion.Euler(0, 0, 1);
            field.transform.RotateAround(transform.position, Vector3.forward, 1.0f);
        }
    }
}
