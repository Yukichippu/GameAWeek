using System.Collections;
using UnityEngine;

namespace SephirothTools.Core
{
    public class SephirothFadeSceneSwitching : MonoBehaviour, ISephirothDataFade
    {
        public static void SceneMove(string sceneName, float speed)
        {
            SephirothCommonFunction.BugDelete1();
            SephirothCommonFunction.SetWait(sceneName, speed, null, null);
            if (ISephirothDataFade.data.IsFading)
            {
                return;
            }

            ISephirothDataFade.data.Speed = speed;
            ISephirothDataFade.data.IsFading = true;

            new GameObject("SephirothSceneSwitchingEffects")
                .AddComponent<SephirothFadeSceneSwitching>()
                .StartCoroutine(nameof(MyCoroutine), sceneName);
        }

        IEnumerator MyCoroutine(string sceneName)
        {
            yield return new WaitForEndOfFrame();

            ISephirothDataFade.data.PreTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            ISephirothDataFade.data.PreTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
            ISephirothDataFade.data.PreTexture.Apply();

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            UnityEngine.SceneManagement.SceneManager.LoadScene("SephirothFadeSceneSwitchingScene", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        }
    }
}
