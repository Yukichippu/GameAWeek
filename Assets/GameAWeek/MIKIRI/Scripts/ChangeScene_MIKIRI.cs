using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_MIKIRI : MonoBehaviour
{
    public void ChangeScene_Game()
    {
        SceneManager.LoadScene("Game");
    }
    public void NextStage()
    {
        Canvas selectUICanvas = GameObject.Find("SelectUICanvas").GetComponent<Canvas>();
        Canvas mainCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        selectUICanvas.enabled = false;
        mainCanvas.enabled = true;
    }
    public void ChangeScene_Result()
    {
        SceneManager.LoadScene("Result");
    }
    public void ChangeScene_Title()
    {
        SceneManager.LoadScene("Title");
    }
}
