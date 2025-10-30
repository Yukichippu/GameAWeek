using TMPro;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private GameManager_RHYTHM gameManager;
    private TextMeshProUGUI textBox;

    [SerializeField] 
    private GameObject effectObj;                       // 生成するエフェクト
    [SerializeField] 
    private GameObject[] foods;                         // 生成するオブジェクト
    [SerializeField] 
    private Vector3 spawnPositionOffset = Vector3.zero; // 生成位置のオフセット

    private void Start()
    {
        gameManager = GameObject.Find("Manager").GetComponent<GameManager_RHYTHM>();
        textBox = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(coll.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                textBox.text = ("(T-T)");
                gameManager.Damaged();
                Destroy(coll.gameObject);
            }
        }

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
        // 生成位置を指定
        Vector3 spawnPos = transform.position + spawnPositionOffset;

        int rand = Random.Range(0, foods.Length);

        GameObject effObj = Instantiate(effectObj, spawnPos, Quaternion.identity);

        GameObject foodObj = Instantiate(foods[rand], spawnPos, Quaternion.identity);
    }
}
