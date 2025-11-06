using TMPro;
using UnityEngine;

public class Timer_LABYRINTH : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float time;
    private float s;
    private float m;

    private void Start()
    {
        time = 0;
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        time += Time.deltaTime;

        s = time;
        m = time / 60;
        
        if (s >= 60)
        {
            s = 0;
        }

        timerText.text = m.ToString() + ":" + s.ToString();
    }
}
