using UnityEngine;

public class GameManager_MIKIRI : MonoBehaviour
{
    private GameObject pObj;
    private GameObject eObj;

    [SerializeField]
    private float flame;
    private bool stop;
    private float randNum;
    private float randMin = 15.0f;
    private float randMax = 50.0f;

    private void Start()
    {
        stop = false;
        randNum = Random.Range(randMin, randMax);
        Debug.Log("randnum: " +  randNum);
    }

    private void Update()
    {
        //1.ランダムで押さないといけない範囲を設定
        //2.3秒待ってから開始
        //3.flame変数の中身が範囲内ならクリア

        if (!stop)
            flame += Time.deltaTime;

        if(Input.GetKey(KeyCode.Space) && !stop)
        {
            flame *= 100;
            flame = (int)flame;
            //Debug.Log("Stop: " + flame);
            stop = true;
        }

        if(stop && flame <= randNum)
        {
            Debug.Log("---CLEAR---,FLAME: " + flame);
        }
        else if(stop && flame >= randNum)
        {
            Debug.Log("---DEFEAT---,FLAME: " + flame);
        }
    }
}
