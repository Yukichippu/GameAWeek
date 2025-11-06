using UnityEngine;

namespace SephirothTools.Core
{
    ///
    /// <summary>
    /// This is the class to reserve when performing a fade during a fade.
    /// </summary>
    /// 
    /// I created this class to avoid freezing in certain situations.
    ///

    public class SephirothExecWait : MonoBehaviour, ISephirothDataFade, ISephirothDataWait
    {
        private string waitSceneName;
        private Vector2? waitPos;
        private float waitSpeed;
        private string waitGrayScaleImageName;

        void Awake()
        {
            ISephirothDataWait.SephirothDataWait data = ISephirothDataWait.data;
            waitSceneName = data.WaitSceneName;
            waitPos = data.WaitPos;
            waitSpeed = data.WaitSpeed;
            waitGrayScaleImageName = data.WaitGrayScaleImageName;
        }

        void Update()
        {
            if(ISephirothDataFade.data.IsFading)
            {
                return;
            }
            if(waitPos.HasValue)
            {
                SephirothSceneSwitchingEffects.CircleWipeSceneSwitch(waitSceneName, waitPos.Value.x, waitPos.Value.y, waitSpeed);
                Destroy(gameObject);
            }
            else if(waitGrayScaleImageName != null)
            {
                SephirothSceneSwitchingEffects.GrayScaleSceneSwitch(waitSceneName, waitGrayScaleImageName, waitSpeed);
                Destroy(gameObject);
            }
            else
            {
                SephirothSceneSwitchingEffects.FadeSceneSwitch(waitSceneName, waitSpeed);
                Destroy(gameObject);
            }
        }
    }
}
