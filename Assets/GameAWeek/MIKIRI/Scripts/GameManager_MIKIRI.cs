using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_MIKIRI : MonoBehaviour
{
    private Canvas          mainCanvas;     //�Q�[����ʂ�Canvas
    private Canvas          selectUICanvas; //�X�e�[�W�N���A��̑I����ʂ�Canvas
    private AudioSource     myAudioSouce;   //AudioSouce

    private Image           exclamationMark;//�r�b�N���}�[�N�̉摜
    private Text            evaText;        //�]��
    private TextMeshProUGUI frameText;      //�t���[�� 
    private TextMeshProUGUI stageNumText;   //�X�e�[�W��
    [SerializeField]
    private AudioClip       se;             //SE

    public float delay     = 50.0f;         //�N���A�ɂȂ�frame�͈̔�

    [SerializeField]
    private float frame;                    //�o�ߎ��Ԃ��i�[����ϐ�
    private bool  stop;                     //�~�߂����ǂ����̃t���O
    private bool  playing;                  //�Q�[������
    private bool  select;                   //�X�e�[�W�N���A��̑I����ʂ��ǂ���
    private bool  oneShot;                  //SE����x�����������߂̕ϐ�
    private float timeStart = 0.0f;         //IsStart�̃^�C�}�[       
    private float timePlay  = 0.0f;         //IsPlay�̃^�C�}�[
    private float timeEnd   = 0.0f;         //IsEnd�̃^�C�}�[
    private float waitTime  = 3.0f;         //�J�n�܂ł̑҂�����
    private float randNum;                  //�����_���Ō��܂鐧������
    private float randMin   = 1.0f;         //randNum�̍ŏ��l
    private float randMax   = 5.0f;         //randNum�̍ő�l
    private int   stageNum  = 1;            //�X�e�[�W��

    private void Start()
    {
        mainCanvas      = GameObject.Find("Canvas").GetComponent<Canvas>();
        selectUICanvas  = GameObject.Find("SelectUICanvas").GetComponent<Canvas>();
        myAudioSouce    = GetComponent<AudioSource>();

        exclamationMark = GameObject.Find("exclamation").GetComponent<Image>();
        evaText         = GameObject.Find("EvaluationText").GetComponent<Text>();
        frameText       = GameObject.Find("FrameText").GetComponent<TextMeshProUGUI>();
        stageNumText    = GameObject.Find("StageText").GetComponent<TextMeshProUGUI>();

        mainCanvas.enabled = true;
        selectUICanvas.enabled = false;

        exclamationMark.enabled = false;
        stop = false;
        playing = false;
        select = true;

        PlayerPrefs.DeleteKey("stageNumber");

        stageNumText.text = ("Stage:") + stageNum.ToString();
        randNum = Random.Range(randMin, randMax);
    }

    private void Update()
    {
        //�ҋ@
        if (!IsStart())
        {            
            return;
        }
        //�J�n
        if (IsPlay())
        {
            exclamationMark.enabled = true;
            playing = true;
        }
        else
        {
            //�т�����}�[�N���o��O�ɃL�[���������ꍇ�^�C�g���ɖ߂�
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

        //frame�̑���
        if (!stop)
            frame += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && !stop)
        {
            //frame�v�Z
            frame *= 60;
            frame = (int)frame;

            //frame�̑������~�߂�
            stop = true;
        }

        //�X�e�[�W�N���A
        if (stop && frame <= delay)
        {
            //�т�����}�[�N�������Ȃ�����
            exclamationMark.enabled = false;

            //�]����frame�̃e�L�X�g���X�V
            frameText.text = frame.ToString();
            evaText.text = ("�������I");

            if (!oneShot)
            {
                myAudioSouce.PlayOneShot(se);
                oneShot = true;
            }

            //���̃X�e�[�W��
            if(IsEnd())
            {
                //selectUICanvas�̑���J�n
                mainCanvas.enabled = false;
                selectUICanvas.enabled = true;

                //selectUICanvas�̑��삪�I���܂Ŏ~�߂�
                if (select)
                {
                    //������Փx�ŃX�^�[�g
                    if (Input.GetKey(KeyCode.Alpha1))
                    {
                        SceneManager.LoadScene("Game");
                    }
                    //��Փx���グ�ăX�^�[�g
                    if (Input.GetKey(KeyCode.Alpha2))
                    {
                        select = false;
                    }
                    //�^�C�g����
                    if (Input.GetKey(KeyCode.Alpha3))
                    {
                        SceneManager.LoadScene("Title");
                    }
                    return;
                }

                //��Փx���グ���ꍇ���̉���ʂ�
                mainCanvas.enabled = true;
                selectUICanvas.enabled = false;

                //�X�e�[�W���X�V
                stageNum++;

                //�X�e�[�W���̃e�L�X�g�X�V
                stageNumText.text = ("Stage:") + stageNum.ToString();

                //��Փx�㏸
                delay -= 5.0f;

                //������
                timeEnd = 0;

                PlayerPrefs.SetInt("stageNum", stageNum);

                //�Q�[���J�n���̏�Ԃɖ߂�
                stop = false;
                playing = false;
                oneShot = false;
                frame = 0;
                evaText.text = ("");
                frameText.text = ("");
                randNum = Random.Range(randMin, randMax);

            }
        }
        //�Q�[���I�[�o�[
        else if (stop && frame >= delay)
        {
            frameText.text = frame.ToString();
            evaText.text = ("�c�O...");

            //���U���g�Ɉړ�
            if (IsEnd())
            {
                SceneManager.LoadScene("Result");
            }
        }
    }
    
    /// <summary>
    /// �J�n�܂�3�b�҂�
    /// </summary>
    /// <returns></returns>
    private bool IsStart()
    {
        if (!playing)
        {
            //3�b�҂�
            timeStart += Time.deltaTime;
            if (timeStart >= waitTime)
            {
                return true;
            }

            return false;
        }
        else
        {
            timeStart = 0;
            return true;
        }
        
    }

    /// <summary>
    /// �r�b�N���}�[�N���o���܂ł̎��Ԃ������_���ő҂�
    /// </summary>
    /// <returns></returns>
    private bool IsPlay()
    {
        if (!playing)
        {
            //�����_���Ȏ��ԑ҂�
            timePlay += Time.deltaTime;
            if (timePlay >= randNum)
            {
                return true;
            }

            return false;
        }
        else
        {
            timePlay = 0; 
            return true;
        }
        
    }

    /// <summary>
    /// �I���܂�3�b�҂�
    /// </summary>
    /// <returns></returns>
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
}
