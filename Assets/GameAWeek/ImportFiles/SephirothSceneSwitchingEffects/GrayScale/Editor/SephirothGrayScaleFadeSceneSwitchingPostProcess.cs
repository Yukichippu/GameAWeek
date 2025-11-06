using UnityEngine;
using UnityEditor;
#pragma warning disable 0618

namespace SephirothTools.Core
{
	public class SephirothGrayScaleFadeSceneSwitchingPostProcess : UnityEditor.Build.IPreprocessBuild, UnityEditor.Build.IPostprocessBuild
	{
		private static bool isCreateStreamingAssets = false;

		public void OnPreprocessBuild(UnityEditor.BuildTarget target, string path)
		{
#if UNITY_EDITOR
			if (!System.IO.Directory.Exists(Application.dataPath + "/StreamingAssets"))
			{
				System.IO.Directory.CreateDirectory(Application.dataPath + "/StreamingAssets");
				isCreateStreamingAssets = true;
			}
			System.IO.Directory.CreateDirectory(Application.dataPath + "/StreamingAssets/SephirothGrayScaleFadeSceneSwitching");
			foreach (string oneFilePath in System.IO.Directory.GetFiles(SephirothRootFolder.GetMyPath() + "SephirothSceneSwitchingEffects/GrayScale/GrayScaleImage"))
			{
				if (oneFilePath.EndsWith(".meta"))
				{
					continue;
				}
				System.IO.File.Copy(oneFilePath, Application.dataPath + "/StreamingAssets/SephirothGrayScaleFadeSceneSwitching/" + System.IO.Path.GetFileName(oneFilePath));
			}
			System.IO.File.Copy(SephirothRootFolder.GetMyPath() + "SephirothSceneSwitchingEffects/GrayScale/Shader/sephiroth_clear_image.png", Application.dataPath + "/StreamingAssets/SephirothGrayScaleFadeSceneSwitching/sephiroth_clear_image.png");
#endif
		}
		public void OnPostprocessBuild(BuildTarget target, string path)
		{
#if UNITY_EDITOR
			DeleteStreamingAssets();
#endif
		}

		public static void DeleteStreamingAssets()
		{
#if UNITY_EDITOR
			FileUtil.DeleteFileOrDirectory(Application.dataPath + "/StreamingAssets/SephirothGrayScaleFadeSceneSwitching");
			if (isCreateStreamingAssets)
			{
				FileUtil.DeleteFileOrDirectory(Application.dataPath + "\\StreamingAssets");
				if (System.IO.File.Exists(Application.dataPath + "\\StreamingAssets.meta"))
				{
					System.IO.File.Delete(Application.dataPath + "\\StreamingAssets.meta");
				}
				isCreateStreamingAssets = false;
			}
#endif
		}

		public int callbackOrder { get { return 0; } }
	}
}
