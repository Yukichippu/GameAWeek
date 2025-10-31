using UnityEngine;

public class Mover : MonoBehaviour
{
    private float       speed       = 0f;                   //�ړ��X�s�[�h
    [SerializeField] 
    private Vector3     direction   = Vector3.right;        //�ړ������i�E�����j

    public void SetSpeed(float newSpeed)
    {
        //���R�[�h����X�s�[�h�̒l���󂯎��
        speed = newSpeed;
    }

    void Update()
    {
        //�ړ�
        transform.position += direction * speed * Time.deltaTime;
    }
}
