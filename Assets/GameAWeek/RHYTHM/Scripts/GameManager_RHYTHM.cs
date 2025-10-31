using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_RHYTHM : MonoBehaviour
{
    public int                  HP = 3;                 //PlayerのHP

    private Timer               timer;                  //Timer.cs
    private Animator            myAnimator;             //PlayerのAnimator
    private GameObject          pObj;                   //Playerのオブジェクト
    private CircleCollider2D    target;                 //攻撃を出す場所のcollider

    private float               timeEnd = 0.0f;         //IsEnd()のためのtime
    private float               waitTime = 3.0f;        //IsEnd()のための待機時間
        
    private void Start()
    {
        timer       = GameObject.Find("Timer").GetComponent<Timer>();
        pObj        = GameObject.Find("Wizard").gameObject;
        myAnimator  = pObj.GetComponent<Animator>();
        target      = GameObject.Find("Target").GetComponent<CircleCollider2D>();

        //初期化(削除)
        PlayerPrefs.DeleteKey("Time");
    }

    private void Update()
    {
        //攻撃
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
                //timerを保管
                PlayerPrefs.SetInt("Time", (int)timer.timer);
                SceneManager.LoadScene("Result");
            }
        }
    }

    private bool IsEnd()
    {
        //3秒待つ
        timeEnd += Time.deltaTime;
        if (timeEnd >= waitTime)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// ダメージを受け時に呼ぶ
    /// </summary>
    public void Damaged()
    {
        HP--;
        myAnimator.SetTrigger("hurt");
    }
}
