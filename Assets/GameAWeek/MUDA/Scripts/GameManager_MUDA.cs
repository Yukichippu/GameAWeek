using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_MUDA : MonoBehaviour
{
    public GameObject[] prefabObj;
    public Image gauge;
    public static float speed = 1.0f;

    [SerializeField]
    Vector2 maxPos;
    [SerializeField]
    float addPoint = 0.1f;
    float max = 0.99f;      //
    float min = 0.0f;       //
    bool onGameOver;        //

    void Start()
    {
        gauge.fillAmount = 0;
        speed /= 10;

        onGameOver = false;
    }

    void Update()
    {
        if(gauge != null && gauge.fillAmount >= 0)
            gauge.fillAmount -= Time.deltaTime*speed;

        if(gauge.fillAmount >= 0.99)
        {
            speed += 0.05f;
            onGameOver = false;
            gauge.fillAmount = 0;
        }
        if(onGameOver && gauge.fillAmount <= 0)
        {
            SceneManager.LoadScene("Result");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            onGameOver = true;

            gauge.fillAmount += addPoint;

            float randX = Random.Range(-maxPos.x, maxPos.x + 1);
            float randY = Random.Range(-maxPos.y, maxPos.y + 1);

            Vector3 genePos = new Vector3(randX, randY, 0);

            GameObject cloneObj = Instantiate(prefabObj[0], genePos, Quaternion.identity);
        }
    }
}
