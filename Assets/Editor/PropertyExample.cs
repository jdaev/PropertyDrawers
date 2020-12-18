using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomPropertyDrawer(typeof(TestScript.Togglable<>))]
    public class PropertyExample : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            SerializedProperty visibilityData = property.FindPropertyRelative("visible");
            SerializedProperty valueData = property.FindPropertyRelative("value");
            
            Rect visibilityRect = new Rect(position.x, position.y, 50, position.height);
            Rect labelRect = new Rect(position.x + 95, position.y, 50, position.height);
            Rect valueRect = new Rect(position.x + 35, position.y, 30, position.height);
            EditorGUI.PropertyField(visibilityRect, property.FindPropertyRelative("visible"),
                GUIContent.none);
            EditorGUI.LabelField(labelRect, label);
            if (visibilityData.boolValue)
            {
                EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("value"), GUIContent.none);
            }

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}