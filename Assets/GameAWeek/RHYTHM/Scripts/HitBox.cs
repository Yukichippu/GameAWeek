using TMPro;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private TextMeshProUGUI textBox;

    private void Start()
    {
        textBox = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("HIT");
            textBox.text = ("GREAT!!");
            Destroy(coll.gameObject);
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                textBox.text = ("MISS");
            }
        }

        
    }
}
