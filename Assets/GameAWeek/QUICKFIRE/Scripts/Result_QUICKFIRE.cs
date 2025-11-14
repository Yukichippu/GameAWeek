using TMPro;
using UnityEngine;

public class Result_QUICKFIRE : MonoBehaviour
{
    private TextMeshProUGUI resultText; //リザルトのスコアを表示するText
    private int resultScore;            //リザルト専用のスコア

    private void Start()
    {
        resultText = GetComponent<TextMeshProUGUI>();

        //最終スコアを代入
        resultScore = GameManager_QUICKFIRE.finalScore;

        //表示
        resultText.text = "SCORE : " + resultScore.ToString();
    }
}
