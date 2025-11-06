using System.Collections.Generic;
using System.Linq;

namespace SephirothTools.Core
{
    public class SephirothFadeSceneSwitchingPostProcessor : UnityEditor.AssetPostprocessor
    {
        private const string BUILD_DIRECTORY_PATH = "SephirothSceneSwitchingEffects/Fade/UseScene";
        private const string SCENE_FILE_EXTENSION = ".unity";

        private static void AddScenes(
        List<UnityEditor.EditorBuildSettingsScene> scene_list,
        string[] imported_asset_paths,
        string[] asset_paths_after_moving
    )
        {
            var adding_scenes = imported_asset_paths
                .Concat(asset_paths_after_moving)
                .Where(asset_path => asset_path.EndsWith(SCENE_FILE_EXTENSION))
                .Where(scene_file_path => scene_file_path.StartsWith(SephirothRootFolder.GetMyPath() + BUILD_DIRECTORY_PATH))
                .Where(scene_file_path => !scene_list.Any(scene => scene.path == scene_file_path))
                .Select(scene_file_path => new UnityEditor.EditorBuildSettingsScene(scene_file_path, true));

            scene_list.AddRange(adding_scenes);
        }

        private static void OnPostprocessAllAssets(
        string[] imported_asset_paths,
        string[] deleted_asset_paths,
        string[] asset_paths_after_moving,
        string[] asset_paths_before_moving
    )
        {
            var scene_list = UnityEditor.EditorBuildSettings.scenes.ToList();

            AddScenes(scene_list, imported_asset_paths, asset_paths_after_moving);
            
            UnityEditor.EditorBuildSettings.scenes = scene_list.ToArray();
        }
    }
}