using UnityEngine;
using UnityEngine.UI;

public class Result_MIKIRI : MonoBehaviour
{
    private Text explanationText;
    private Text stageText;

    private void Start()
    {
        int stageNumR = PlayerPrefs.GetInt("stageNum", 0);
        explanationText = GameObject.Find("ExplanationText").GetComponent<Text>();
        stageText = GameObject.Find("StageText").GetComponent<Text>();

        stageText.text = ("Stage") + stageNumR.ToString();
    }
}
