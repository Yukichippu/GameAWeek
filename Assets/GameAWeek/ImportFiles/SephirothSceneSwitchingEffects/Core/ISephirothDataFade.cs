using UnityEngine;

namespace SephirothTools.Core
{
    /// <summary>
    /// The class you use must inherit ISephirothDataFade.
    /// </summary>
    public interface ISephirothDataFade
    {

        protected static readonly SephirothDataFade data = new();

        public class SephirothDataFade
        {
            // common start

            public bool IsFading { get; set; }
            public Texture2D PreTexture { get; set; }
            public float Speed { get; set; }

            // common end
            // gray scale start

            public Texture2D GrayScaleImage { get; set; }

            // gray scale end
            // circle wipe start

            public Vector2 TargetPoint { get; set; }

            // circle wipe end
        }

        protected static void MyInit()
        {
            if (data.PreTexture != null)
            {
                Object.Destroy(data.PreTexture);
                data.PreTexture = null;
            }
            if (data.GrayScaleImage != null)
            {
                Object.Destroy(data.GrayScaleImage);
                data.PreTexture = null;
            }
            data.IsFading = false;
        }
    }
}
