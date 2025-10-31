using TMPro;
using UnityEngine;

public class Result_RHYTHM : MonoBehaviour
{
    private TextMeshProUGUI resultText; //¶‘¶ŠÔ‚ğ•\¦‚·‚éText

    private void Start()
    {
        //•ÛŠÇ‚µ‚Ä‚¢‚½’l‚ğ‘ã“ü
        int resultTime = PlayerPrefs.GetInt("Time", 0); 
        resultText = GetComponent<TextMeshProUGUI>();
        resultText.text = "LifeTime " + resultTime.ToString();
    }
}
