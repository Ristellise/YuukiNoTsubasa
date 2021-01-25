

namespace Assets.YuukiNoTsubasa
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using UnityEditor;
    using UnityEditor.Build.Pipeline;
    using UnityEditor.Build.Pipeline.Interfaces;
    using UnityEditor.Build.Pipeline.Tasks;
    using UnityEngine;
    public static class Core
    {
        [MenuItem("File/Yuuki Build/Build Now")]
        public static void Setup()
        {
            BuildContext buildContext = new BuildContext();
            Progress(0.0f, "Setup [Switch Platform, Rebuild SpriteAtlasCache]");
            List<IBuildTask> setupTask = new List<IBuildTask> { new SwitchToBuildPlatform(), new RebuildSpriteAtlasCache() };
            var validation = BuildTasksRunner.Validate(setupTask, buildContext);
            if ((int)validation < 0)
            {
                Debug.LogError($"Validation Failed @ Setup: {validation}");
            }
            Debug.Log($"Validation Success: {validation}");
            Thread.Sleep(500);
            ClearProgress();
        }

        public static void Progress(float percent, string currentStep)
        {
            float total = 100.0f;
            EditorUtility.DisplayProgressBar("Builing Assets", $"Step: {currentStep}", percent / total);
        }

        public static void ClearProgress()
        {
            EditorUtility.ClearProgressBar();
        }
    }

}

