#pragma warning disable 0618
using System.Collections;
using UnityEngine;

namespace SephirothTools.Core
{
    public class SephirothGrayScaleFadeSceneSwitching : MonoBehaviour, ISephirothDataFade
    {
        private static bool isInit = false;

        public static void SceneMove(string sceneName, string grayScaleImageName, float speed)
        {
            SephirothCommonFunction.BugDelete1();
            SephirothCommonFunction.SetWait(sceneName, speed, null, grayScaleImageName);
            if (ISephirothDataFade.data.IsFading)
            {
                return;
            }

            Texture2D texture2D = new(2, 2);
            try
            {
#if UNITY_EDITOR
                texture2D.LoadImage(System.IO.File.ReadAllBytes(SephirothRootFolder.GetMyPath() + "SephirothSceneSwitchingEffects/GrayScale/GrayScaleImage/" + grayScaleImageName));
#else
                grayScaleImageName = Application.streamingAssetsPath + "/SephirothGrayScaleFadeSceneSwitching/" + grayScaleImageName;
                if (!grayScaleImageName.Contains("file:"))
                {
                    grayScaleImageName = "file://" + grayScaleImageName;
                }

                texture2D.LoadImage(LoadImage(grayScaleImageName, 0));
#endif
                ISephirothDataFade.data.Speed = speed;
                ISephirothDataFade.data.IsFading = true;
                ISephirothDataFade.data.GrayScaleImage = texture2D;

                new GameObject("SephirothSceneSwitchingEffects")
                    .AddComponent<SephirothGrayScaleFadeSceneSwitching>()
                    .StartCoroutine(nameof(MyCoroutine), sceneName);
            }
            catch(System.Exception e)
            {
                Debug.LogError(e.StackTrace);

                SephirothSceneSwitchingEffects.CircleWipeSceneSwitch(sceneName, 0.5f, 0.5f, speed);

                Destroy(texture2D);
            }
        }

#if !UNITY_EDITOR
        private static byte[] LoadImage(string grayScaleImageName, int tryCount)
        {
            //I thought about using UnityWebRequestTexture.GetTexture, but decided to do it this way for stability.
            //May be an old article, but I've seen some bad reviews about UnityWebRequestTexture's stability on the internet.

            using (UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequest.Get(grayScaleImageName))
            {
                request.SendWebRequest();

                ulong oldDownloadByte = 0; 
                ulong count = 0;
                bool isError = false;
                while (!isError)
                {
                    switch ( request.result )
                    {
                        case UnityEngine.Networking.UnityWebRequest.Result.Success:
                            return request.downloadHandler.data;
                        case UnityEngine.Networking.UnityWebRequest.Result.ConnectionError:
                        case UnityEngine.Networking.UnityWebRequest.Result.ProtocolError:
                        case UnityEngine.Networking.UnityWebRequest.Result.DataProcessingError:
                            isError = true;
                            break;
                        default:
                            break;
                    }

                    count++;
                    if(count % 1000 == 0 && 10000 < count)
                    {
                        if (request.downloadedBytes <= oldDownloadByte)
                        {
                            isError = true;
                        }
                        oldDownloadByte = request.downloadedBytes;
                    }
                }
            }
            if(tryCount == 200) {
                throw new System.Exception("Image loading failed 200 times.");
            }
            return LoadImage(grayScaleImageName, tryCount + 1);
        }
#endif

        IEnumerator MyCoroutine(string sceneName)
        {
            yield return new WaitForEndOfFrame();

            ISephirothDataFade.data.PreTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            ISephirothDataFade.data.PreTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
            ISephirothDataFade.data.PreTexture.Apply();

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            UnityEngine.SceneManagement.SceneManager.LoadScene("SephirothGrayScaleFadeSceneSwitchingScene", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            if (isInit) return;
            Texture2D texture2D = new(2, 2);
            try
            {
#if UNITY_EDITOR
                texture2D.LoadImage(System.IO.File.ReadAllBytes(SephirothRootFolder.GetMyPath() + "SephirothSceneSwitchingEffects/GrayScale/Shader/sephiroth_clear_image.png"));
#else
                string grayScaleImageName = Application.streamingAssetsPath + "/SephirothGrayScaleFadeSceneSwitching/sephiroth_clear_image.png";
                if (!grayScaleImageName.Contains("file:"))
                {
                    grayScaleImageName = "file://" + grayScaleImageName;
                }

                texture2D.LoadImage(LoadImage(grayScaleImageName, 0));
#endif
            }
            catch
            {
            }
            Destroy(texture2D);
            isInit = true;
        }
    }
}
