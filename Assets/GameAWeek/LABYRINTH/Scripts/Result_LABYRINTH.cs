using TMPro;
using UnityEngine;

public class Result_LABYRINTH : MonoBehaviour
{
    private TextMeshProUGUI resultText;

    private void Start()
    {
        resultText = GetComponent<TextMeshProUGUI>();
        Debug.Log("Final Time: " + Timer_LABYRINTH.finalTime);
        int m = (int)(Timer_LABYRINTH.finalTime / 60);
        int s = (int)(Timer_LABYRINTH.finalTime % 60);

        resultText.text = string.Format("{0:00}:{1:00}", m, s);
    }
}

