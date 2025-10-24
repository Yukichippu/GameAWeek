using UnityEngine;
using UnityEngine.UI;

public class Result_MIKIRI : MonoBehaviour
{
    private Text stageText; //突破したステージ数を表示するText

    private void Start()
    {
        //GameManager_MIKIRIのstageNumを代入
        int stageNumR = PlayerPrefs.GetInt("stageNum", 0);

        stageText = GameObject.Find("StageText").GetComponent<Text>();

        //表示
        stageText.text = ("Stage") + stageNumR.ToString();
    }
}
