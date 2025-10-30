using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange_RHYTHM : MonoBehaviour
{
    public void SceneChange_Game()
    {
        SceneManager.LoadScene("Game");
    }
    public void SceneChange_Title()
    {
        SceneManager.LoadScene("Title");
    }
}
