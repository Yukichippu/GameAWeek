using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger_DON_K : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
