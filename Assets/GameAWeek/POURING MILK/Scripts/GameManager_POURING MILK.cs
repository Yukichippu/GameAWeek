using UnityEngine;
using UnityEngine.UI;

public class GameManager_POURINGMILK : MonoBehaviour
{
    public Image milkImage;

    float speed = 0.5f;

    void Start()
    {
        milkImage.fillAmount = 0;    
    }

    void Update()
    {
        milkImage.fillAmount += Time.deltaTime * speed;

        if(milkImage.fillAmount >= 1)
        {
            //ゲームオーバー
        }
    }
}
