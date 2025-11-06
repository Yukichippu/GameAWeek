using UnityEngine;

namespace SephirothTools.Core
{
    public class DemoSceneSephirothFadeSceneSwitching : MonoBehaviour
    {
        private static bool isExecAwake = false;

#if UNITY_EDITOR
        void Awake()
        {
            if (isExecAwake)
            {
                return;
            }
            int count = 0;
            for (int i = 0; i < UnityEditor.EditorBuildSettings.scenes.Length; i++)
            {
                for (int j = 1; j <= 2; j++)
                {

                    string oneSceneName = System.IO.Path.GetFileName(UnityEditor.EditorBuildSettings.scenes[i].path);
                    if (oneSceneName.Equals("SephirothFadeSceneSwitchingDemoScene" + j + ".unity"))
                    {
                        count++;
                        break;
                    }
                }
            }
            if (count < 2)
            {
                Debug.LogError("When using a demo scene, you need to register the scene in \"Scenes In Build\".");
            }
            isExecAwake = true;
        }
#endif

        public void MyExec(string sceneName)
        {
            SephirothTools.SephirothSceneSwitchingEffects.FadeSceneSwitch(sceneName);
        }
    }
}
