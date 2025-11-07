using SephirothTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger_LABYRINTH : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //プレイヤーが当たったら
        if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //タイマーの停止
            Timer_LABYRINTH timer = GameObject.Find("Timer").GetComponent<Timer_LABYRINTH>();
            timer.StopTimer();

            //シーンをフェードで切り替え
            SephirothSceneSwitchingEffects.FadeSceneSwitch("Result", 1.0f);
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
