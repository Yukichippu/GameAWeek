using UnityEngine;

namespace SephirothTools.Core
{
    public class SephirothFadeSceneSwitchingCore : MonoBehaviour, ISephirothDataFade, ISephirothDataWait
    {
        private float progress = 1;

        [SerializeField]
        private UnityEngine.UI.Image SephirothWipeImage;

        void Awake()
        {
            SephirothWipeImage.material.SetTexture("_MainTex", ISephirothDataFade.data.PreTexture);
            SephirothWipeImage.material.SetFloat("_AlphaValue", 1);
        }

        void Start()
        {
            ISephirothDataWait.data.IsWaitTiming = true;
        }

        void FixedUpdate()
        {
            progress -= 0.02f * ISephirothDataFade.data.Speed;

            if (0 < progress)
            {
                SephirothWipeImage.material.SetFloat("_AlphaValue", progress * progress);
            }
            else
            {
                ISephirothDataFade.MyInit();
                ISephirothDataWait.MyInit();
                UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("SephirothFadeSceneSwitchingScene");
            }
        }
    }
}
