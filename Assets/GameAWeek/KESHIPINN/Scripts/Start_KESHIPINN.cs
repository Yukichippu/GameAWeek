using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_KESHIPINN : MonoBehaviour
{
    private TextMeshProUGUI text;
    private float duration = 1.0f;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Blink());
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Game");
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            // フェードアウト
            yield return StartCoroutine(FadeTextAlpha(1f, 0f, duration));

            // フェードイン
            yield return StartCoroutine(FadeTextAlpha(0f, 1f, duration));
        }
    }

    IEnumerator FadeTextAlpha(float from, float to, float time)
    {
        float t = 0f;
        Color c = text.color;

        while (t < time)
        {
            t += Time.deltaTime;
            float a = Mathf.Lerp(from, to, t / time);
            text.color = new Color(c.r, c.g, c.b, a);
            yield return null;
        }
    }
}
