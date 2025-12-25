using UnityEngine;
using UnityEditor;
using System.IO;

namespace NullStack.Editor
{
    public static class CreateNullStackSettings
    {
        [MenuItem("Assets/Create/NullStack/Settings")]
        public static void CreateSettings()
        {
            NullStackSettings asset = ScriptableObject.CreateInstance<NullStackSettings>();

            string path = "Assets/Resources";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string assetPath = AssetDatabase.GenerateUniqueAssetPath($"{path}/NullStackSettings.asset");

            AssetDatabase.CreateAsset(asset, assetPath);
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;

            Debug.Log($"[NullStack] Settings asset created at: {assetPath}");
            EditorUtility.DisplayDialog(
                "NullStack Settings Created",
                $"Settings file created at:\n{assetPath}\n\nPlease configure your Base URL, Title ID, and Secret Key.",
                "OK"
            );
        }

        [MenuItem("NullStack/Create Settings Asset")]
        public static void CreateSettingsFromMenu()
        {
            CreateSettings();
        }

        [MenuItem("NullStack/Documentation")]
        public static void OpenDocumentation()
        {
            Application.OpenURL("https://github.com/Lunaractive/unity-sdk");
        }

        [MenuItem("NullStack/Report Issue")]
        public static void ReportIssue()
        {
            Application.OpenURL("https://github.com/Lunaractive/unity-sdk/issues");
        }
    }
}
