using UnityEngine;
using UnityEngine.UI;

public class Result_MIKIRI : MonoBehaviour
{
    private Text stageText; //�˔j�����X�e�[�W����\������Text

    private void Start()
    {
        //GameManager_MIKIRI��stageNum����
        int stageNumR = PlayerPrefs.GetInt("stageNum", 0);

        stageText = GameObject.Find("StageText").GetComponent<Text>();

        //�\��
        stageText.text = ("Stage") + stageNumR.ToString();
    }
}
