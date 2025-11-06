using UnityEngine;

namespace SephirothTools.Core
{
    public class SephirothGrayScaleFadeSceneSwitchingCore : MonoBehaviour, ISephirothDataFade, ISephirothDataWait
    {
        private float progress = 0;

        [SerializeField]
        private UnityEngine.UI.Image SephirothWipeImage;

        void Awake()
        {
            SephirothWipeImage.material.SetTexture("_MainTex", ISephirothDataFade.data.PreTexture);
            SephirothWipeImage.material.SetFloat("_CircleValue", progress);
            SephirothWipeImage.material.SetTexture("_GrayScaleTex", ISephirothDataFade.data.GrayScaleImage);
        }

        void Start()
        {
            ISephirothDataWait.data.IsWaitTiming = true;
        }

        void FixedUpdate()
        {
            progress += 0.02f * ISephirothDataFade.data.Speed;

            if (progress < 1.15f)
            {
                SephirothWipeImage.material.SetFloat("_CircleValue", progress);
            }
            else
            {
                ISephirothDataFade.MyInit();
                ISephirothDataWait.MyInit();
                UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("SephirothGrayScaleFadeSceneSwitchingScene");
            }
        }
    }
}
