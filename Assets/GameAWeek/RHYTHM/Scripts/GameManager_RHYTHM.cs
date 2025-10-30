using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_RHYTHM : MonoBehaviour
{
    public int HP = 3;

    private Timer timer;
    private Animator myAnimator;
    private GameObject pObj;
    private CircleCollider2D target;

    private float timeEnd = 0.0f;
    private float waitTime = 3.0f;

    private void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        pObj = GameObject.Find("Wizard").gameObject;
        myAnimator = pObj.GetComponent<Animator>();
        target = GameObject.Find("Target").GetComponent<CircleCollider2D>();

        PlayerPrefs.DeleteKey("Time");
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

        if(HP < 0)
        {
            myAnimator.SetTrigger("die");
            if (IsEnd())
            {
                PlayerPrefs.SetInt("Time", (int)timer.timer);
                SceneManager.LoadScene("Result");
            }
        }
    }

    private bool IsEnd()
    {
        //3•b‘Ò‚Â
        timeEnd += Time.deltaTime;
        if (timeEnd >= waitTime)
        {
            return true;
        }

        return false;
    }

    public void Damaged()
    {
        HP--;
        myAnimator.SetTrigger("hurt");
    }
}
