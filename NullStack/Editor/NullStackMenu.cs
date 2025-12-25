using UnityEngine;
using UnityEditor;

namespace NullStack.Editor
{
    public static class NullStackMenu
    {
        [MenuItem("NullStack/Quick Start Guide", priority = 0)]
        public static void ShowQuickStart()
        {
            string message = @"NullStack Unity SDK - Quick Start

1. CREATE SETTINGS
   • Right-click in Project → Create → NullStack → Settings
   • Or use menu: NullStack → Create Settings Asset
   • Save as 'NullStackSettings' in Assets/Resources/

2. CONFIGURE SETTINGS
   • Base URL: http://localhost:3001 (or your server URL)
   • Title ID: Get from Developer Portal
   • Secret Key: Get from Developer Portal

3. LOGIN PLAYER
   Create a script:

   using NullStack.API;

   void Start() {
       string deviceId = SystemInfo.deviceUniqueIdentifier;

       StartCoroutine(
           NullStackClient.Instance.Authentication.LoginWithCustomId(
               deviceId,
               createAccount: true,
               OnLoginSuccess,
               OnLoginError
           )
       );
   }

   void OnLoginSuccess(LoginResponse response) {
       Debug.Log(""Logged in: "" + response.data.player.username);
   }

   void OnLoginError(string error) {
       Debug.LogError(""Login failed: "" + error);
   }

4. USE FEATURES
   • Player Data: NullStackClient.Instance.Player
   • Leaderboards: NullStackClient.Instance.Leaderboards
   • Economy: NullStackClient.Instance.Economy
   • CloudScript: NullStackClient.Instance.CloudScript
   • Matchmaking: NullStackClient.Instance.Matchmaking
   • Analytics: NullStackClient.Instance.Analytics

Check the Examples folder for complete code samples!
";

            EditorUtility.DisplayDialog("NullStack Quick Start", message, "Got it!");
        }

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

        [MenuItem("NullStack/API Documentation", priority = 20)]
        public static void OpenAPIDocs()
        {
            Application.OpenURL("https://github.com/Lunaractive/NullStack");
        }

        [MenuItem("NullStack/Unity SDK Repository", priority = 21)]
        public static void OpenSDKRepo()
        {
            Application.OpenURL("https://github.com/Lunaractive/unity-sdk");
        }

        [MenuItem("NullStack/Examples", priority = 22)]
        public static void OpenExamples()
        {
            string examplesPath = "Packages/com.lunaractive.nullstack/Examples";

            Object examplesFolder = AssetDatabase.LoadAssetAtPath<Object>(examplesPath);

            if (examplesFolder != null)
            {
                Selection.activeObject = examplesFolder;
                EditorGUIUtility.PingObject(examplesFolder);
            }
            else
            {
                EditorUtility.DisplayDialog(
                    "Examples",
                    "Examples can be found in:\nNullStack/Examples/NullStackExample.cs\n\nThis file contains complete usage examples for all features.",
                    "OK"
                );
            }
        }

        [MenuItem("NullStack/About", priority = 50)]
        public static void ShowAbout()
        {
            string message = @"NullStack Unity SDK v1.0.0

Open-source backend services for game developers.

A product of Lunaractive

Features:
• Authentication (Email, Custom ID, Device ID)
• Player Data & Profiles
• CloudScript Execution
• Leaderboards & Rankings
• Virtual Economy
• Matchmaking
• Analytics

GitHub: github.com/Lunaractive/unity-sdk
License: MIT
";

            EditorUtility.DisplayDialog("About NullStack SDK", message, "Close");
        }
    }
}
