using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger_QUICKFIRE : MonoBehaviour
{
    public void SceneChange_Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void SceneChange_Game()
    {
        SceneManager.LoadScene("Game");
    }
}
