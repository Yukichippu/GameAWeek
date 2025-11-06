using UnityEngine;

namespace SephirothTools.Core
{
    public class DemoSceneSephirothWipeSceneSwitching : MonoBehaviour
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
                    if (oneSceneName.Equals("SephirothWipeSceneSwitchingDemoScene" + j + ".unity"))
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
            //If you want to start from the last touch point
            SephirothTools.SephirothSceneSwitchingEffects
                .CircleWipeSceneSwitchAtLastTouchPoint(sceneName);

            //If you want to start from a specific point.
            //SephirothTools.SephirothSceneSwitchingEffects
            //    .CircleWipeSceneSwitch(sceneName, 0.8f, 0.8f); 

            //If you want to start from a specific point at outside the screen.
            //SephirothTools.SephirothSceneSwitchingEffects
            //    .CircleWipeSceneSwitch(sceneName, 0.5f, -0.3f); 
        }
    }
}
