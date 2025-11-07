using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager_QUICKFIRE : MonoBehaviour
{
    private TextMeshProUGUI questionText;   //

    //出題範囲のキーとKeyCodeの対応表
    private Dictionary<string, KeyCode> keyValues = new Dictionary<string, KeyCode>()
    {
        {"S", KeyCode.S},
        {"D", KeyCode.D},
        {"F", KeyCode.F},
        {"J", KeyCode.J},
        {"K", KeyCode.K},
        {"L", KeyCode.L},
    };

    private string  currentKey;             //現在選ばれているキー名
    private KeyCode currentCode;            //現在選ばれているKeyCode
    private float   currentTime;            //経過時間
    private float   waitTime = 3f;          //待機時間
    private int     score;                  //スコア
    private bool    isQuizActive;    //クイズがアクティブかどうか

    public static int finalScore;           //最終スコア

    private void Start()
    {
        questionText = GameObject.Find("Question").GetComponent<TextMeshProUGUI>();

        //最初から出題されるようにするため
        currentTime = 3.0f;

        //最初のキーを選ぶ
        ChooseRandomKey();
        isQuizActive = false;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime <= waitTime) 
            return;
        else 
            isQuizActive = true;

        if (isQuizActive)
        {
            //次のキーを選ぶ
            ChooseRandomKey();
            isQuizActive = false;
        }

        if (Input.GetKeyDown(currentCode))
        {
            //スコア加算
            score++;
            //初期化
            currentTime = 0f;
            Debug.Log($"正解！ スコア: {score}");
        }
        else
        {
            //スコア減算
            score--;
            //初期化
            currentTime = 0f;
            Debug.Log($"不正解！ スコア: {score}");
        }
    }

    /// <summary>
    /// 問題のキーをランダムに選ぶ
    /// </summary>
    void ChooseRandomKey()
    {
        //keyValuesからランダムに1つ選ぶ
        List<string> keys = new List<string>(keyValues.Keys);
        int randomIndex = Random.Range(0, keys.Count);

        currentKey = keys[randomIndex];
        currentCode = keyValues[currentKey];

        questionText.text = currentKey;
        Debug.Log($"次に押すキーは：{currentKey}");
    }
}
