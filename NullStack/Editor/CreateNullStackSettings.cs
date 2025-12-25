using UnityEngine;
using UnityEditor;
using System.IO;
using NullStack;

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
        }

        [MenuItem("NullStack/Create Settings Asset")]
        public static void CreateSettingsFromMenu()
        {
            CreateSettings();
        }
    }
}
