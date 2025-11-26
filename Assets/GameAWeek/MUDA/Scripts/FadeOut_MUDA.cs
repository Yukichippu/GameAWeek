using UnityEngine;

public class FadeOut_MUDA : MonoBehaviour
{
    SpriteRenderer mySRenderer;
    Color myColor;

    [SerializeField]
    float speed = 1.0f;

    void Start()
    {
        mySRenderer = GetComponent<SpriteRenderer>();
        myColor = mySRenderer.color;
    }

    void Update()
    {
        myColor.a -= Time.deltaTime * speed;
        mySRenderer.color = myColor;
    }
}
