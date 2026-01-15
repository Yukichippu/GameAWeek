using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager_BLOCK : MonoBehaviour
{
    public static int score;
    public static int hp;

    public TextMeshProUGUI scoreText;
    public GameObject gamaoverText;
    public GameObject[] hearts;

    void Start()
    {
        gamaoverText.SetActive(false);
        hp = 3;
    }

    void Update()
    {
        scoreText.text = score.ToString();

        switch (hp)
        {
            case 0:
                hearts[0].SetActive(false);
                hearts[1].SetActive(false);
                hearts[2].SetActive(false);
                gamaoverText.SetActive(true);
                break;
            case 1:
                hearts[0].SetActive(true);
                hearts[1].SetActive(false);
                hearts[2].SetActive(false);
                break;
            case 2:
                hearts[0].SetActive(true);
                hearts[1].SetActive(true);
                hearts[2].SetActive(false);
                break;
            case 3:
                hearts[0].SetActive(true);
                hearts[1].SetActive(true);
                hearts[2].SetActive(true);
                break;
        }
    }
}
