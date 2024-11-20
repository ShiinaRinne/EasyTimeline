using UnityEditor;
using UnityEngine;

using MAOTimelineExtension.Runtime;

namespace MAOTimelineExtension.Editor
{
    [CustomEditor(typeof(MAOTimelineExtensionVolumeSettings))]
    public class MAOTimelineExtensionVolumeSettingsEditor : UnityEditor.Editor
    {
        SerializedProperty autoSwitchVolumeAccessType;
        SerializedProperty manualVolumeAccessType;

        private void OnEnable()
        {
            autoSwitchVolumeAccessType = serializedObject.FindProperty("autoSwitchVolumeAccessType");
            manualVolumeAccessType = serializedObject.FindProperty("manualVolumeAccessType");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(autoSwitchVolumeAccessType, new GUIContent("Auto Switch Access Type"));

            using (new EditorGUI.DisabledGroupScope(autoSwitchVolumeAccessType.boolValue))
            {
                EditorGUILayout.PropertyField(manualVolumeAccessType, new GUIContent("Volume Access Type"));
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}