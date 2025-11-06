using UnityEngine;

namespace SephirothTools.Core
{
    [UnityEditor.InitializeOnLoad]
    public class SephirothGrayScaleRotateFunction
    {
        /**
         * Rotates each image stored in
         * "Assets/SephirothSceneSwitchingEffects/GrayScale/GrayScaleImage"
         * by 90 degrees.
         */
        [UnityEditor.MenuItem("Tools/SephirothSceneSwitchingEffects/ExecSephirothGrayScaleRotateFunction")]
        public static void Exec()
        {
            string targetDirectoryPath = SephirothRootFolder.GetMyPath() + "SephirothSceneSwitchingEffects/GrayScale/GrayScaleImage";
            string backUpDirectoryPath = targetDirectoryPath + "/BackUp" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
            System.IO.Directory.CreateDirectory(backUpDirectoryPath);
            foreach(string oneFilePath in System.IO.Directory.GetFiles(targetDirectoryPath))
            {
                if (oneFilePath.EndsWith(".meta"))
                {
                    continue;
                }
                System.IO.File.Copy(oneFilePath, backUpDirectoryPath + "/" + System.IO.Path.GetFileName(oneFilePath));
            }
            foreach (string oneFilePath in System.IO.Directory.GetFiles(targetDirectoryPath))
            {
                if (oneFilePath.EndsWith(".meta"))
                {
                    continue;
                }
                Texture2D loadTexture2D = new(2, 2);
                loadTexture2D.LoadImage(System.IO.File.ReadAllBytes(oneFilePath));
                Texture2D resultTexture2D = new(loadTexture2D.height, loadTexture2D.width);
                for(int i = 0; i < loadTexture2D.width; i++)
                {
                    for(int j = 0; j < loadTexture2D.height; j++)
                    {
                        resultTexture2D.SetPixel(j, i, loadTexture2D.GetPixel(i, j));
                    }
                }
                System.IO.File.WriteAllBytes(oneFilePath, resultTexture2D.EncodeToPNG());
            }
            UnityEditor.AssetDatabase.Refresh();
        }
    }
}
