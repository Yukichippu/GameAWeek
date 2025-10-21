using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_MIKIRI : MonoBehaviour
{
    private GameObject pObj;
    private GameObject eObj;
    private Image exclamationMark;  //�r�b�N���}�[�N�̉摜

    [SerializeField]
    private float flame;                //�o�ߎ��Ԃ��i�[����ϐ�
    private bool stop;                  //�~�߂����ǂ����̃t���O
    private float timeStart = 0.0f;
    private float timePlay  = 0.0f;
    private float waitTime  = 3.0f;     //�J�n�܂ł̑҂�����
    private float randNum;              //�����_���Ō��܂鐧������
    private float randMin   = 1.0f;    //randNum�̍ŏ��l
    private float randMax   = 5.0f;    //randNum�̍ő�l

    private void Start()
    {
        exclamationMark = GameObject.Find("exclamation").GetComponent<Image>();

        exclamationMark.enabled = false;
        stop = false;

        randNum = Random.Range(randMin, randMax);
        Debug.Log("randnum: " + randNum);
    }

    private void Update()
    {
        //1.�����_���ŉ����Ȃ��Ƃ����Ȃ��͈͂�ݒ�
        //2.3�b�҂��Ă���J�n
        //3.flame�ϐ��̒��g���͈͓��Ȃ�N���A

        //3�b�҂�
        Debug.Log(IsStart());
        if (!IsStart())
        {            
            Debug.Log("Wait Time...");
            return;
        }
        Debug.Log("----------------Start!----------------");
        //�J�n
        if (IsPlay())
        {
            exclamationMark.enabled = true;
            Debug.Log("-----------------Play!-----------------");
        }



        ////��
        //if (!stop)
        //    flame += Time.deltaTime;

        //if(Input.GetKey(KeyCode.Space) && !stop)
        //{
        //    flame *= 100;
        //    flame = (int)flame;
        //    //Debug.Log("Stop: " + flame);
        //    stop = true;
        //}

        //if(stop && flame <= randNum)
        //{
        //    Debug.Log("---CLEAR---,FLAME: " + flame);
        //}
        //else if(stop && flame >= randNum)
        //{
        //    Debug.Log("---DEFEAT---,FLAME: " + flame);
        //}
    }
    
    private bool IsStart()
    {
        timeStart += Time.deltaTime;   
        if (timeStart >= waitTime)
        {
            return true;
        }

        return false;
    }

    private bool IsPlay()
    {
        timePlay += Time.deltaTime;
        if (timePlay >= randNum)
        {
            return true;
        }

        return false;
    }

    private bool NextStage()
    {
        return false;
    }   
}
