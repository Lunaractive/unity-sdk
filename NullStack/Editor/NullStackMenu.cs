using UnityEngine;
using UnityEditor;
using NullStack;

namespace NullStack.Editor
{
    public static class NullStackMenu
    {
        [MenuItem("NullStack/Settings Asset", priority = 1)]
        public static void OpenSettings()
        {
            var settings = Resources.Load<NullStackSettings>("NullStackSettings");

            if (settings == null)
            {
                bool create = EditorUtility.DisplayDialog(
                    "Settings Not Found",
                    "NullStackSettings asset not found in Resources folder.\n\nWould you like to create it now?",
                    "Create",
                    "Cancel"
                );

                if (create)
                {
                    CreateNullStackSettings.CreateSettings();
                }
            }
            else
            {
                Selection.activeObject = settings;
                EditorGUIUtility.PingObject(settings);
            }
        }

        [MenuItem("NullStack/Documentation", priority = 20)]
        public static void OpenDocumentation()
        {
            Application.OpenURL("https://github.com/Lunaractive/unity-sdk");
        }

        [MenuItem("NullStack/Report Issue", priority = 21)]
        public static void ReportIssue()
        {
            Application.OpenURL("https://github.com/Lunaractive/unity-sdk/issues");
        }

        [MenuItem("NullStack/About", priority = 50)]
        public static void ShowAbout()
        {
            EditorUtility.DisplayDialog(
                "About NullStack SDK",
                "NullStack Unity SDK v1.0.0\n\n" +
                "Open-source backend services for game developers.\n\n" +
                "A product of Lunaractive\n\n" +
                "GitHub: github.com/Lunaractive/unity-sdk\n" +
                "License: MIT",
                "Close"
            );
        }
    }
}
