namespace SephirothTools.Core
{
    /// <summary>
    /// This is a class that allows it to function properly with multithreading.
    /// </summary>
    public static class SephirothThreadCore
    {
        private static readonly object Lock = new();

        public static void CircleWipeSceneSwitch(string sceneName, float speed)
        {
            lock (Lock)
            {
                SephirothWipeSceneSwitching.SceneMove(sceneName, speed);
            }
        }

        public static void CircleWipeSceneSwitch(string sceneName, float posX, float posY, float speed)
        {
            lock (Lock)
            {
                SephirothWipeSceneSwitching.SceneMove(sceneName, posX, posY, speed);
            }
        }

        public static void FadeSceneSwitch(string sceneName, float speed)
        {
            lock (Lock)
            {
                SephirothFadeSceneSwitching.SceneMove(sceneName, speed);
            }
        }

        public static void GrayScaleSceneSwitch(string sceneName, string grayScaleImageName, float speed)
        {
            lock (Lock)
            {
                SephirothGrayScaleFadeSceneSwitching.SceneMove(sceneName, grayScaleImageName, speed);
            }
        }
    }
}
