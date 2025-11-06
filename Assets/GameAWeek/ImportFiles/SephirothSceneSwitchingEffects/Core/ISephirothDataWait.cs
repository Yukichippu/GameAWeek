using UnityEngine;

namespace SephirothTools.Core
{
    /// <summary>
    /// The class you use must inherit ISephirothDataWait.
    /// </summary>
    public interface ISephirothDataWait
    {
        protected static readonly SephirothDataWait data = new();

        public class SephirothDataWait
        {
            public bool IsWaitTiming { get; set; }
            public string WaitSceneName { get; set; }
            public Vector2? WaitPos { get; set; }
            public float WaitSpeed { get; set; }
            public string WaitGrayScaleImageName { get; set; }
        }

        protected static void MyInit()
        {
            data.WaitSceneName = null;
            data.WaitPos = null;
            data.WaitGrayScaleImageName = null;
            data.IsWaitTiming = false;
        }
    }
}
