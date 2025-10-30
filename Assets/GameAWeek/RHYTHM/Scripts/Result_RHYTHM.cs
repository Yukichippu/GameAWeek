using TMPro;
using UnityEngine;

public class Result_RHYTHM : MonoBehaviour
{
    private TextMeshProUGUI resultText;
    private void Start()
    {
        int resultTime = PlayerPrefs.GetInt("Time", 0);
        resultText = GetComponent<TextMeshProUGUI>();
        resultText.text = "LifeTime " + resultTime.ToString();
    }
}
