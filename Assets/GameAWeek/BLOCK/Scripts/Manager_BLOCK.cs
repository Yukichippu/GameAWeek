using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager_BLOCK : MonoBehaviour
{
    public static int score;
    public static int hp;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gamaoverText;
    public Image[] hearts;

    void Start()
    {
        gamaoverText.enabled = false;
    }

    void Update()
    {
        scoreText.text = score.ToString();

        switch (hp)
        {
            case 0:
                gamaoverText.enabled = true;
                break;
            case 1:
                hearts[0].enabled = true;
                break;
            case 2:
                hearts[0].enabled = true;
                hearts[1].enabled = true;
                break;
            case 3:
                hearts[0].enabled = true;
                hearts[1].enabled = true;
                hearts[2].enabled = true;
                break;
        }
    }
}
