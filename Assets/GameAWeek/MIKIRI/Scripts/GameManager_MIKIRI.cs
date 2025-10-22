using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_MIKIRI : MonoBehaviour
{
    private Image exclamationMark;      //�r�b�N���}�[�N�̉摜
    private Text evaText;    //�]��
    private TextMeshProUGUI frameText;  //�t���[�� 

    [SerializeField]
    private float delay     = 20.0f;    //
    [SerializeField]
    private float frame;                //�o�ߎ��Ԃ��i�[����ϐ�
    private bool stop;                  //�~�߂����ǂ����̃t���O
    private float timeStart = 0.0f;
    private float timePlay  = 0.0f;
    private float timeEnd   = 0.0f;
    private float waitTime  = 3.0f;     //�J�n�܂ł̑҂�����
    private float randNum;              //�����_���Ō��܂鐧������
    private float randMin   = 1.0f;     //randNum�̍ŏ��l
    private float randMax   = 5.0f;     //randNum�̍ő�l

    private void Start()
    {
        exclamationMark = GameObject.Find("exclamation").GetComponent<Image>();
        evaText         = GameObject.Find("EvaluationText").GetComponent<Text>();
        frameText       = GameObject.Find("FrameText").GetComponent<TextMeshProUGUI>();

        exclamationMark.enabled = false;
        stop = false;

        randNum = Random.Range(randMin, randMax);
    }

    private void Update()
    {
        //1.�����_���ŉ����Ȃ��Ƃ����Ȃ��͈͂�ݒ�
        //2.3�b�҂��Ă���J�n
        //3.flame�ϐ��̒��g���͈͓��Ȃ�N���A

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
            Debug.Log("-----------------Play!----------------");
        }
        else
        {
            if(Input.GetKey(KeyCode.Space))
            {
                evaText.text = ("����t��!!");
                
                if (IsEnd())
                {
                    SceneManager.LoadScene("Title");
                }
            }
            return;
        }

        //��
        if (!stop)
            frame += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && !stop)
        {
            frame *= 60;
            frame = (int)frame;
            stop = true;
        }

        if (stop && frame <= delay)
        {
            exclamationMark.enabled = false;
            frameText.text = frame.ToString();
            evaText.text = ("�������I");
            Debug.Log("---CLEAR---,FLAME: " + frame);

            if(IsEnd())
            {
                SceneManager.LoadScene("Result");
            }
        }
        else if (stop && frame >= delay)
        {
            frameText.text = frame.ToString();
            evaText.text = ("�c�O...");
            Debug.Log("---DEFEAT---,FLAME: " + frame);

            if (IsEnd())
            {
                SceneManager.LoadScene("Result");
            }
        }
    }
    
    private bool IsStart()
    {
        //3�b�҂�
        timeStart += Time.deltaTime;   
        if (timeStart >= waitTime)
        {
            return true;
        }

        return false;
    }

    private bool IsPlay()
    {
        //�����_���Ȏ��ԑ҂�
        timePlay += Time.deltaTime;
        if (timePlay >= randNum)
        {
            return true;
        }

        return false;
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

    private bool NextStage()
    {
        return false;
    }   
}
