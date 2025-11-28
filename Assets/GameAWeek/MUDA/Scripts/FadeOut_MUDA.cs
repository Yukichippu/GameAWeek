using UnityEngine;

public class FadeOut_MUDA : MonoBehaviour
{
    SpriteRenderer mySRenderer; //SpriteRenderer
    Color myColor;              //代入する色

    [SerializeField]
    float speed = 1.0f;         //消えるスピード

    void Start()
    {
        mySRenderer = GetComponent<SpriteRenderer>();

        //最初の色を保存
        myColor = mySRenderer.color;
    }

    void Update()
    {
        //フェードアウト
        myColor.a -= Time.deltaTime * speed;
        mySRenderer.color = myColor;
    }
}
