using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger_MUDA : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
