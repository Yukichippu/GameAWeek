using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_DON_K : MonoBehaviour
{
    public GameObject prefabObj;
    public GameObject eObj;

    private float time = 0f;
    [SerializeField]
    private float spownDuration = 1.0f;

    private void Update()
    {
        //一定時間ごとにオブジェクト生成
        time += Time.deltaTime;
        if (time >= spownDuration)
        {
            GameObject cloneObj = Instantiate(prefabObj, eObj.transform.position, Quaternion.identity);
            time = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            //クリア
            SceneManager.LoadScene("Result");
        }
    }
}
