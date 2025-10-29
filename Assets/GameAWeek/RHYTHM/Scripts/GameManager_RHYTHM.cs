using UnityEngine;

public class GameManager_RHYTHM : MonoBehaviour
{
    private Animator myAnimator;
    private GameObject pObj;
    private CircleCollider2D target;

    private void Start()
    {
        pObj = GameObject.Find("Wizard").gameObject;
        myAnimator = pObj.GetComponent<Animator>();
        target = GameObject.Find("Target").GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myAnimator.SetTrigger("attack");
            target.enabled = true;
        }
        else
        {
            target.enabled = false;
        }
    }
}
