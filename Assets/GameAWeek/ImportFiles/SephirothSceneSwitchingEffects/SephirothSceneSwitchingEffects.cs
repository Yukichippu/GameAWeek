namespace SephirothTools
{
    /// <summary>
    /// <para>
    /// SephirothSceneSwitchingEffects asset body.
    /// </para>
    /// 
    /// <para>
    /// SephirothSceneSwitchingEffects asset
    /// use the methods of this class by executing them.
    /// </para>
    /// 
    /// <para>
    /// GrayScaleSceneSwitch method will not work
    /// unless the grayscale image is stored in a specific folder.
    /// </para>
    /// </summary>
    public static class SephirothSceneSwitchingEffects
    {
        ///
        /// <summary>
        /// <para>
        /// Wipe in a widening circle from the last touch point.
        /// </para>
        /// 
        /// <para>
        /// Use like 
        /// SephirothTools.SephirothSceneSwitchingEffects.CircleWipeSceneSwitch
        /// ("SceneA");
        /// </para>
        /// </summary>
        ///
        public static void CircleWipeSceneSwitchAtLastTouchPoint(string sceneName, float speed = 1f)
        {
            Core.SephirothThreadCore.CircleWipeSceneSwitch(sceneName, speed);
        }

        /// 
        /// <summary>
        /// <para>
        /// Wipe in a way that the circle spreads out from a specific point.
        /// </para>
        /// 
        /// <para>
        /// Use like 
        /// SephirothTools.SephirothSceneSwitchingEffects.CircleWipeSceneSwitch
        /// ("SceneA", 0.1f, 0.9f);
        /// </para>
        /// </summary>
        ///
        /// Set posX and posY in the range 0 to 1,
        /// unless you start outside the screen.
        ///
        /// The larger posX, the more right the starting point.
        /// The larger posY, the more bottom the starting point.
        ///
        /// For example, if "posX = 0.1f" and "posY = 0.9f",
        /// wipe as a circle spreads from the bottom left.
        ///
        /// For example, if "posX = 0.9f" and "posY = 0.1f",
        /// wipe as a circle spreads from the top right.
        /// 
        public static void CircleWipeSceneSwitch(string sceneName, float posX, float posY,  float speed = 1f)
        {
            Core.SephirothThreadCore.CircleWipeSceneSwitch(sceneName, posX, posY, speed);
        }

        ///
        /// <summary>
        /// <para>
        /// Fade to transition between screens.
        /// </para>
        /// 
        /// <para>
        /// Use like 
        /// SephirothTools.SephirothSceneSwitchingEffects.FadeSceneSwitch
        /// ("SceneA");
        /// </para>
        /// </summary>
        ///
        public static void FadeSceneSwitch(string sceneName, float speed = 1f)
        {
            Core.SephirothThreadCore.FadeSceneSwitch(sceneName, speed);
        }

        ///
        /// <summary>
        /// <para>
        /// Fade based on grayscale image.
        /// </para>
        /// 
        /// <para>
        /// Use like
        /// SephirothTools.SephirothSceneSwitchingEffects.GrayScaleSceneSwitch
        /// ("SceneA", "grayScaleImage1.png");
        /// </para>
        /// 
        /// <para>
        /// Please store grayscale images in
        /// "Assets/SephirothSceneSwitchingEffects/GrayScale/GrayScaleImage".
        /// </para>
        /// 
        /// </summary>
        /// 
        /// Various fades can be performed, such as going around clockwise.
        /// 
        /// You can rotate the grayscale image to be used by executing
        /// Tools > ExecSephirothGrayScaleRotateFunction.
        ///
        public static void GrayScaleSceneSwitch(string sceneName, string grayScaleImageName, float speed = 1f)
        {
            Core.SephirothThreadCore.GrayScaleSceneSwitch(sceneName, grayScaleImageName, speed);
        }
    }
}
