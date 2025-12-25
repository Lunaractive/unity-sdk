using UnityEngine;
using UnityEditor;

namespace NullStack.Editor
{
    [CustomEditor(typeof(NullStackSettings))]
    public class NullStackSettingsEditor : UnityEditor.Editor
    {
        private SerializedProperty baseUrl;
        private SerializedProperty titleId;
        private SerializedProperty secretKey;

        private SerializedProperty authEndpoint;
        private SerializedProperty playerEndpoint;
        private SerializedProperty cloudScriptEndpoint;
        private SerializedProperty leaderboardEndpoint;
        private SerializedProperty economyEndpoint;
        private SerializedProperty matchmakingEndpoint;
        private SerializedProperty analyticsEndpoint;

        private SerializedProperty enableLogging;
        private SerializedProperty logApiCalls;

        private bool showEndpoints = false;

        private void OnEnable()
        {
            baseUrl = serializedObject.FindProperty("baseUrl");
            titleId = serializedObject.FindProperty("titleId");
            secretKey = serializedObject.FindProperty("secretKey");

            authEndpoint = serializedObject.FindProperty("authEndpoint");
            playerEndpoint = serializedObject.FindProperty("playerEndpoint");
            cloudScriptEndpoint = serializedObject.FindProperty("cloudScriptEndpoint");
            leaderboardEndpoint = serializedObject.FindProperty("leaderboardEndpoint");
            economyEndpoint = serializedObject.FindProperty("economyEndpoint");
            matchmakingEndpoint = serializedObject.FindProperty("matchmakingEndpoint");
            analyticsEndpoint = serializedObject.FindProperty("analyticsEndpoint");

            enableLogging = serializedObject.FindProperty("enableLogging");
            logApiCalls = serializedObject.FindProperty("logApiCalls");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("NullStack Settings", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("Configure your NullStack backend connection settings.", MessageType.Info);
            EditorGUILayout.Space();

            // Server Configuration
            EditorGUILayout.LabelField("Server Configuration", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(baseUrl, new GUIContent("Base URL", "Your NullStack server URL (e.g., http://localhost:3001)"));
            EditorGUILayout.Space();

            // Title Configuration
            EditorGUILayout.LabelField("Title Configuration", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(titleId, new GUIContent("Title ID", "Your game's title ID from the Developer Portal"));
            EditorGUILayout.PropertyField(secretKey, new GUIContent("Secret Key", "Your title's secret key (keep secure!)"));

            if (!string.IsNullOrEmpty(secretKey.stringValue))
            {
                EditorGUILayout.HelpBox("⚠️ Secret Key is set. Keep this secure and never commit to version control!", MessageType.Warning);
            }
            EditorGUILayout.Space();

            // Service Endpoints (Collapsible)
            showEndpoints = EditorGUILayout.Foldout(showEndpoints, "Service Endpoints (Advanced)", true);
            if (showEndpoints)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(authEndpoint, new GUIContent("Auth Endpoint"));
                EditorGUILayout.PropertyField(playerEndpoint, new GUIContent("Player Endpoint"));
                EditorGUILayout.PropertyField(cloudScriptEndpoint, new GUIContent("CloudScript Endpoint"));
                EditorGUILayout.PropertyField(leaderboardEndpoint, new GUIContent("Leaderboard Endpoint"));
                EditorGUILayout.PropertyField(economyEndpoint, new GUIContent("Economy Endpoint"));
                EditorGUILayout.PropertyField(matchmakingEndpoint, new GUIContent("Matchmaking Endpoint"));
                EditorGUILayout.PropertyField(analyticsEndpoint, new GUIContent("Analytics Endpoint"));
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.Space();

            // Debug Settings
            EditorGUILayout.LabelField("Debug Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(enableLogging, new GUIContent("Enable Logging", "Show debug logs in console"));
            EditorGUILayout.PropertyField(logApiCalls, new GUIContent("Log API Calls", "Log all HTTP requests (verbose)"));
            EditorGUILayout.Space();

            // Validation
            if (GUILayout.Button("Validate Settings"))
            {
                ValidateSettings();
            }

            EditorGUILayout.Space();

            serializedObject.ApplyModifiedProperties();
        }

        private void ValidateSettings()
        {
            bool isValid = true;
            string message = "Settings Validation:\n\n";

            // Check Base URL
            if (string.IsNullOrEmpty(baseUrl.stringValue))
            {
                message += "❌ Base URL is required\n";
                isValid = false;
            }
            else if (!baseUrl.stringValue.StartsWith("http://") && !baseUrl.stringValue.StartsWith("https://"))
            {
                message += "⚠️ Base URL should start with http:// or https://\n";
            }
            else
            {
                message += "✓ Base URL is set\n";
            }

            // Check Title ID
            if (string.IsNullOrEmpty(titleId.stringValue))
            {
                message += "❌ Title ID is required\n";
                isValid = false;
            }
            else
            {
                message += "✓ Title ID is set\n";
            }

            // Check Secret Key
            if (string.IsNullOrEmpty(secretKey.stringValue))
            {
                message += "⚠️ Secret Key is not set (required for some operations)\n";
            }
            else
            {
                message += "✓ Secret Key is set\n";
            }

            if (isValid)
            {
                message += "\n✅ Settings are valid and ready to use!";
                EditorUtility.DisplayDialog("Settings Valid", message, "OK");
            }
            else
            {
                message += "\n❌ Please fix the errors above.";
                EditorUtility.DisplayDialog("Settings Invalid", message, "OK");
            }
        }
    }
}
