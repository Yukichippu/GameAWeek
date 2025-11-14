using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_QUICKFIRE : MonoBehaviour
{
    private TextMeshProUGUI questionText;   //問題を表示するText
    private TextMeshProUGUI scoreText;      //スコアを表示するText
    private Image           correctObj;     //〇
    private Image           inCorrectObj;   //×
    private GameObject      parentObjT;     //タイマーの親オブジェクト
    private GameObject      parentObjH;     //HPの親オブジェクト

    [SerializeField]
    private GameObject[]    timeObjs;       //タイマー
    [SerializeField]
    private GameObject[]    hpObjs;         //HP

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
    [SerializeField]
    private float   currentTimeA;           //経過時間(クイズ出題前)
    private float   currentTimeB;           //制限時間(クイズ出題後)
    private float   waitTime = 1.0f;        //待機時間
    private int     score;                  //スコア
    private int     countT;                 //タイマーの子オブジェクトの個数
    private int     countH;                 //HPの子オブジェクトの個数
    private bool    isQuizActive;           //クイズがアクティブかどうか
    private bool    onTimer;                //タイマーが起動するためのフラグ

    public static int finalScore;           //最終スコア

    private void Start()
    {
        questionText    = GameObject.Find("Question").GetComponent<TextMeshProUGUI>();
        correctObj      = GameObject.Find("Correct").GetComponent<Image>();
        inCorrectObj    = GameObject.Find("Incorrect").GetComponent<Image>();
        scoreText       = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        parentObjT      = GameObject.Find("Time").gameObject;
        parentObjH      = GameObject.Find("HP").gameObject;

        //〇×を非表示
        correctObj.enabled = false;
        inCorrectObj.enabled = false;

        //配列の個数を別に保存
        countT = parentObjT.transform.childCount;
        countH = parentObjH.transform.childCount;

        //サイズ確保
        timeObjs = new GameObject[countT];
        hpObjs = new GameObject[countH];

        //子オブジェト格納
        for(int t = 0;  t < parentObjT.transform.childCount; t++)
        {
            timeObjs[t] = parentObjT.transform.GetChild(t).gameObject;
        }
        for(int h = 0; h < parentObjH.transform.childCount; h++)
        {
            hpObjs[h] = parentObjH.transform.GetChild(h).gameObject;
        }

        //タイマー初期化
        currentTimeA = 0.0f;
        currentTimeB = 0.0f;
        isQuizActive = false;
        onTimer = true;

        //最初のキーを選ぶ
        ChooseRandomKey();
    }

    private void Update()
    {
        scoreText.text = score.ToString();

        currentTimeA += Time.deltaTime;

        //1秒待つ
        if (currentTimeA > waitTime) isQuizActive = true;
        else return;

        if (isQuizActive && onTimer)
        {
            //次のキーを選ぶ
            ChooseRandomKey();
            
            onTimer = false;
        }
        else if (isQuizActive)
        {
            //タイマー
            InQuizTimer();
        }

        //キーが押されたとき
        if (Input.anyKeyDown)
        {
            //正解が押されたとき
            if (Input.GetKeyDown(currentCode))
            {
                //スコア加算
                score++;

                //初期化
                currentTimeA = 0f;
                currentTimeB = 0f;
                for (int t = 0; t < timeObjs.Length; t++)
                {
                    if(countT < timeObjs.Length) countT++;
                    timeObjs[t].SetActive(true);
                }
                questionText.text = " ";
                onTimer = true;
                StartCoroutine(FlashCorrect(correctObj, 0.5f));
                Debug.Log($"正解！ スコア: {score}");
            }
            //不正解のとき
            else
            {
                //スコア減算
                score--;

                //HP減少
                countH--;
                hpObjs[countH].SetActive(false);

                //初期化
                currentTimeA = 0f;
                currentTimeB = 0f;
                for (int t = 0; t < timeObjs.Length; t++)
                {
                    if (countT < timeObjs.Length) countT++;
                    timeObjs[t].SetActive(true);
                }
                questionText.text = " ";
                onTimer = true;
                StartCoroutine(FlashCorrect(inCorrectObj, 0.5f));
                Debug.Log($"不正解！ スコア: {score}");
            }
        }

        //リザルトへ
        if(countH <= 0 || countT <= 0)
        {
            finalScore = score;
            SceneManager.LoadScene("Result");
            Debug.Log("----- ゲームオーバー -----");
        }
    }

    /// <summary>
    /// 問題のキーをランダムに選ぶ
    /// </summary>
    private void ChooseRandomKey()
    {
        //keyValuesからランダムに1つ選ぶ
        List<string> keys = new List<string>(keyValues.Keys);
        int randomIndex = Random.Range(0, keys.Count);

        currentKey = keys[randomIndex];
        currentCode = keyValues[currentKey];

        questionText.text = currentKey;
        //Debug.Log($"次に押すキーは：{currentKey}");
    }

    /// <summary>
    /// 制限時間
    /// </summary>
    private void InQuizTimer()
    {
        currentTimeB += Time.deltaTime;
        //1秒経過ごとの処理
        if(currentTimeB >= 1.0f && countT != 0)
        {
            currentTimeB = 0.0f;
            countT--;
            timeObjs[countT].SetActive(false);
        }
    }

    /// <summary>
    /// 指定された秒数表示する
    /// </summary>
    /// <param name="image">表示するImage</param>
    /// <param name="t">秒数</param>
    /// <returns></returns>
    private IEnumerator FlashCorrect(Image image, float t)
    {
        image.enabled = true;
        yield return new WaitForSeconds(t);
        image.enabled = false;
        yield return null;
    }
}
