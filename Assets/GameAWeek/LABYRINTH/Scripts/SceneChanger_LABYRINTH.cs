using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger_LABYRINTH : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            SceneManager.LoadScene("Result");
        }
    }

    public void ChangeScene_Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void ChangeScene_Title()
    {
        SceneManager.LoadScene("Title");
    }
}
