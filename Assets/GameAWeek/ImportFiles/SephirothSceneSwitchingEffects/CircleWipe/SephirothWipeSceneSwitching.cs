using System.Collections;
using UnityEngine;

namespace SephirothTools.Core
{
    public class SephirothWipeSceneSwitching : MonoBehaviour, ISephirothDataFade
    {
        public static void SceneMove(string sceneName, float speed)
        {
            Vector2 hitPoint;
            try
            {
                if (0 < Input.touchCount)
                {
                    hitPoint = Input.GetTouch(0).position;
                }
                else
                {
                    hitPoint = Input.mousePosition;
                }
            }
            catch
            {
                hitPoint = new Vector2(0.5f, 0.5f);
            }

            float posX = hitPoint.x / Screen.width;
            float posY = 1 - hitPoint.y / Screen.height;

            SceneMove(sceneName, posX, posY, speed);
        }

        public static void SceneMove(string sceneName, float posX, float posY, float speed)
        {
            SephirothCommonFunction.BugDelete1();
            SephirothCommonFunction.SetWait(sceneName, speed, new Vector2(posX, posY), null);
            if (ISephirothDataFade.data.IsFading)
            {
                return;
            }

            ISephirothDataFade.data.TargetPoint = new Vector2(posX, 1 - posY);
            ISephirothDataFade.data.Speed = speed;
            ISephirothDataFade.data.IsFading = true;

            new GameObject("SephirothSceneSwitchingEffects")
                .AddComponent<SephirothWipeSceneSwitching>()
                .StartCoroutine(nameof(MyCoroutine), sceneName);
        }

        IEnumerator MyCoroutine(string sceneName)
        {
            yield return new WaitForEndOfFrame();

            ISephirothDataFade.data.PreTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            ISephirothDataFade.data.PreTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
            ISephirothDataFade.data.PreTexture.Apply();

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            UnityEngine.SceneManagement.SceneManager.LoadScene("SephirothWipeSceneSwitchingScene", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        }
    }
}
