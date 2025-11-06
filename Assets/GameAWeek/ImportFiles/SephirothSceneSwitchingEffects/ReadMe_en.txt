SephirothSceneSwitchingEffects - A collection of effects for scene transitions that do not go through a pitch black screen. / Ver1.00.0
Copyright (c) 2024 GiftedStyle

===
Introduction

The effects you use as you move through a scene can make or break the impression of your app.
SephirothSceneSwitchingEffects provides her four effects:
- Move the scene so that the circle spreads from the last touch point.
- Move the scene so that the circle spreads from a specific point.
- Move the scene with a fade.
- Move the scene based on the grayscale image.

Transition directly without going through a black screen.

With the ability to fade based on grayscale images, you can create the effect yourself if you have the skill to create grayscale images.

To use SephirothSceneSwitchingEffects, just run a method similar to
"SephirothTools.SephirothSceneSwitchingEffects.CircleWipeSceneSwitchAtLastTouchPoint(string sceneName);".

If you want to use the "Fade based on a grayscale image" effect, please store the grayscale image in "Assets/SephirothSceneSwitchingEffects/GrayScale/GrayScaleImage".

There is no timing to load the front and back of the scene at the same time.
So you can move between scenes without any problem, even if the previous or next scene requires a lot of memory.

For example, if you want to move the scene so that the circle spreads, follow the steps below.
step1: Convert the screen to Texture2D just before moving the scene.
step2: Unload the scene.
step3: Load the next scene.
step4: Display the above Texture2D to fill the screen and spread it out so that it spreads like a circle.

You can also darken the border.
Please check the reference video for a version with darker borders.
If you want to darken the border, please perform the work written in Shader. (Uncomment out)

When you import this asset, the SephirothSceneSwitchingEffects folder will be placed directly under Assets.
This SephirothSceneSwitchingEffects folder can be moved to another folder.

You might want to automatically perform a fade only once, such as scene to load.
To avoid freezing in such cases, if you perform a fade during a fade, the fade will only be reserved once.
The reserved fade will be executed after the fade is completed.

Confirmed to work on Android and iOS.

---
Example of use

Please use this asset by executing the method in SephirothSceneSwitchingEffects.cs.

If you want to use the "Move the scene as a circle expands from the last touch point" effect, use SephirothTools.SephirothSceneSwitchingEffects.CircleWipeSceneSwitchAtLastTouchPoint(string sceneName) instead of UnityEngine.SceneManagement.SceneManager.LoadScene(string sceneName).

By setting the speed part of
SephirothTools.SephirothSceneSwitchingEffects.CircleWipeSceneSwitchAtLastTouchPoint(string sceneName, float speed = 1f),
you can change the speed at which the circle spreads.

If you want to use the "Fade based on a grayscale image" effect, please store the grayscale image in "Assets/SephirothSceneSwitchingEffects/GrayScale/GrayScaleImage".
Files stored in the above folder will be saved in StreamingAssets. We recommend removing unused images before output.

By executing "Tools/SephirothSceneSwitchingEffects/ExecSephirothGrayScaleRotateFunction", rotate the image stored in "Assets/SephirothSceneSwitchingEffects/GrayScale/GrayScaleImage" by 90 degrees.

Grayscale images are used by stretching them.
We recommend using grayscale images that do not look strange even when stretched.
When using a vertical screen, we recommend using a vertical grayscale image.

To use this asset, you need to add the scene in the UseScene folder to "Scenes In Build".
When you import an asset, it is automatically targeted, but if you accidentally remove it, please re-insert it.

If you want to try DemoScene, please put the scene in DemoScene into "Scenes In Build".

Confirmed to work on Android and iOS.