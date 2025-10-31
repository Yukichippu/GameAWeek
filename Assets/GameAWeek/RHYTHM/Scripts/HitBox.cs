using TMPro;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private GameManager_RHYTHM  gameManager;                            //GameManager_RHYTHM.cs
    private TextMeshProUGUI     textBox;                                //�]����\������Text

    [SerializeField] 
    private GameObject          effectObj;                              //��������G�t�F�N�g
    [SerializeField] 
    private GameObject[]        foods;                                  //��������I�u�W�F�N�g
    [SerializeField] 
    private Vector3             spawnPositionOffset = Vector3.zero;     //�����ʒu�̃I�t�Z�b�g

    private void Start()
    {
        gameManager     = GameObject.Find("Manager").GetComponent<GameManager_RHYTHM>();
        textBox         = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Player��Enemy���Ԃ������ꍇ
        if(gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(coll.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                textBox.text = ("(T-T)");
                gameManager.Damaged();
                Destroy(coll.gameObject);
            }
        }

        //���̑��̃I�u�W�F�N�g��Enemy�ƂԂ������ꍇ
        if (coll.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            textBox.text = ("GREAT!!");
            Destroy(coll.gameObject);
            SpawnObject();
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                textBox.text = ("MISS");
            }
        }
    }

    private void SpawnObject()
    {
        // �����ʒu���w��
        Vector3 spawnPos = transform.position + spawnPositionOffset;
        // foods�������_���ɌĂяo�����߂̕ϐ�
        int rand = Random.Range(0, foods.Length);

        //����
        GameObject effObj = Instantiate(effectObj, spawnPos, Quaternion.identity);
        GameObject foodObj = Instantiate(foods[rand], spawnPos, Quaternion.identity);
    }
}
