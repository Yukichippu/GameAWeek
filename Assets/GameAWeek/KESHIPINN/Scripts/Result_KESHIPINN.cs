using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result_KESHIPINN : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        text.text = Judge_KESHIPINN.winner;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
