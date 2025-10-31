using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_RHYTHM : MonoBehaviour
{
    public int                  HP = 3;                 //Player��HP

    private Timer               timer;                  //Timer.cs
    private Animator            myAnimator;             //Player��Animator
    private GameObject          pObj;                   //Player�̃I�u�W�F�N�g
    private CircleCollider2D    target;                 //�U�����o���ꏊ��collider

    private float               timeEnd = 0.0f;         //IsEnd()�̂��߂�time
    private float               waitTime = 3.0f;        //IsEnd()�̂��߂̑ҋ@����
        
    private void Start()
    {
        timer       = GameObject.Find("Timer").GetComponent<Timer>();
        pObj        = GameObject.Find("Wizard").gameObject;
        myAnimator  = pObj.GetComponent<Animator>();
        target      = GameObject.Find("Target").GetComponent<CircleCollider2D>();

        //������(�폜)
        PlayerPrefs.DeleteKey("Time");
    }

    private void Update()
    {
        //�U��
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
                //timer��ۊ�
                PlayerPrefs.SetInt("Time", (int)timer.timer);
                SceneManager.LoadScene("Result");
            }
        }
    }

    private bool IsEnd()
    {
        //3�b�҂�
        timeEnd += Time.deltaTime;
        if (timeEnd >= waitTime)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// �_���[�W���󂯎��ɌĂ�
    /// </summary>
    public void Damaged()
    {
        HP--;
        myAnimator.SetTrigger("hurt");
    }
}
