namespace SephirothTools.Core
{
    public class SephirothCommonFunction : ISephirothDataFade, ISephirothDataWait
    {
        /// <summary>
        /// Eliminate bugs under specific circumstances. (I use GameObject.Find, but it rarely goes into this, so it doesn't slow down the operation.)
        /// </summary>
        public static void BugDelete1()
        {
            if (!ISephirothDataFade.data.IsFading)
            {
                return;
            }
            try
            {
                for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
                {
                    string oneSceneName = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i).name;
                    if (oneSceneName.Equals("SephirothWipeSceneSwitchingScene")
                            || oneSceneName.Equals("SephirothFadeSceneSwitchingScene")
                            || oneSceneName.Equals("SephirothGrayScaleFadeSceneSwitchingScene"))
                    {
                        return;
                    }
                }
            }
            catch
            {
                string oneSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                if (oneSceneName.Equals("SephirothWipeSceneSwitchingScene")
                        || oneSceneName.Equals("SephirothFadeSceneSwitchingScene")
                        || oneSceneName.Equals("SephirothGrayScaleFadeSceneSwitchingScene"))
                {
                    return;
                }
            }

            UnityEngine.GameObject oldGameObject = UnityEngine.GameObject.Find("SephirothSceneSwitchingEffects");
            if (oldGameObject != null)
            {
                UnityEngine.Object.Destroy(oldGameObject);
            }

            ISephirothDataFade.MyInit();
            ISephirothDataWait.MyInit();
        }

        public static void SetWait(string waitSceneName, float waitSpeed, UnityEngine.Vector2? waitPos, string waitGrayScaleImageName)
        {
            if (ISephirothDataWait.data.IsWaitTiming && ISephirothDataWait.data.WaitSceneName == null)
            {
                ISephirothDataWait.data.WaitSceneName = waitSceneName;
                ISephirothDataWait.data.WaitSpeed = waitSpeed;
                ISephirothDataWait.data.WaitPos = waitPos;
                ISephirothDataWait.data.WaitGrayScaleImageName = waitGrayScaleImageName;
                new UnityEngine.GameObject("SephirothExecWait")
                .AddComponent<SephirothExecWait>();
            }
        }
    }
}
