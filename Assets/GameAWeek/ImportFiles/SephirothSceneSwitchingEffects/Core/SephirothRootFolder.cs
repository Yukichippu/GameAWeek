namespace SephirothTools.Core
{
    ///
    /// <summary>
    /// This is the class that searches where
    /// the SephirothSceneSwitchingEffects folder is located.
    /// </summary>
    /// 
    /// It is created so that it will function properly even if
    /// the SephirothSceneSwitchingEffects folder is moved to another folder.
    /// 
    /// This tool is never used on a real device
    /// Therefore, the presence of this tool does not slow things down.
    ///
    public static class SephirothRootFolder
    {
        public static string GetMyPath()
        {
            string result = "Assets/";

            foreach (string onePath in System.IO.Directory.GetDirectories(UnityEngine.Application.dataPath, "*", System.IO.SearchOption.AllDirectories))
            {
                if (onePath.Contains("SephirothSceneSwitchingEffects"))
                {
                    string onePathSub = onePath.Replace("\\", "/");
                    if(0 < onePathSub.IndexOf("/Assets/"))
                    {
                        onePathSub = onePathSub.Substring(onePathSub.IndexOf("/Assets/") + 1);
                    }
                    else if(onePathSub.StartsWith("Assets/"))
                    {
                        //Measures to take when the specification of System.IO.Directory.GetDirectories changes and the path starts with Assets

                        //DO NOTTING
                    }
                    else
                    {
                        //Measures to take when the specification of System.IO.Directory.GetDirectories changes to an unexpected return value
                        
                        continue;
                    }
                    
                    if (onePathSub.Contains("SephirothSceneSwitchingEffects"))
                    {
                        result = onePathSub.Substring(0, onePathSub.LastIndexOf("SephirothSceneSwitchingEffects"));
                        break;
                    }
                }
            }

            return result;
        }
    }
}