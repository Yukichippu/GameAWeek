using UnityEngine;

namespace SephirothTools.Core
{
    public class SephirothWipeSceneSwitchingCore : MonoBehaviour, ISephirothDataFade, ISephirothDataWait
    {
        private float progress = 0;
        private int frameCount = 0;
        private float myDistance;

        [SerializeField]
        private UnityEngine.UI.Image SephirothWipeImage;

        void Awake()
        {
            SephirothWipeImage.material.SetTexture("_MainTex", ISephirothDataFade.data.PreTexture);
            SephirothWipeImage.material.SetFloat("_CircleValue", progress);

            SephirothWipeImage.material.SetFloat("_FirstX", ISephirothDataFade.data.TargetPoint.x);
            SephirothWipeImage.material.SetFloat("_FirstY", ISephirothDataFade.data.TargetPoint.y);

            SetMyDistance();
        }

        void Start()
        {
            ISephirothDataWait.data.IsWaitTiming = true;
        }

        void SetMyDistance()
        {
            float posX = ISephirothDataFade.data.TargetPoint.x;
            float posY = ISephirothDataFade.data.TargetPoint.y;

            Vector2 thinkingVector = new();
            
            if(posX < 0.5f)
            {
                if (posY < 0.5f)
                {
                    thinkingVector.x = 1f - posX;
                    thinkingVector.y = 1f - posY;
                }
                else
                {
                    thinkingVector.x = 1f - posX;
                    thinkingVector.y = posY;
                }
            }
            else
            {
                if (posY < 0.5f)
                {
                    thinkingVector.x = posX;
                    thinkingVector.y = 1f - posY;
                }
                else
                {
                    thinkingVector.x = posX;
                    thinkingVector.y = posY;
                }
            }

            float w = ISephirothDataFade.data.PreTexture.width;
            float h = ISephirothDataFade.data.PreTexture.height;
            if (w < h)
            {
                thinkingVector.x *= h / w;
            }
            else
            {
                thinkingVector.y *= w / h;
            }

            myDistance = thinkingVector.magnitude + 0.3f;
        }

        void FixedUpdate()
        {
            progress += (frameCount + 240) * 0.00013f * ISephirothDataFade.data.Speed;

            if (progress < myDistance)
            {
                SephirothWipeImage.material.SetFloat("_CircleValue", progress);
            }
            else
            {
                ISephirothDataFade.MyInit();
                ISephirothDataWait.MyInit();
                UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("SephirothWipeSceneSwitchingScene");
            }

            frameCount++;
        }
    }
}
