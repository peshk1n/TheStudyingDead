using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(DialogTrigger))]
public class DialogTriggerEditor : UnityEditor.Editor
{
    private SerializedProperty _modeProperty;

    private void OnEnable()
    {
        _modeProperty = serializedObject.FindProperty("_mode");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(_modeProperty);
        if (_modeProperty.GetEnum(out DialogTrigger.Mode mode))
        {
            switch (mode)
            {
                case DialogTrigger.Mode.Bound:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_bound"));
                    break;
                case DialogTrigger.Mode.External:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_external"));
                    break;
            }
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_action"));
        }
        serializedObject.ApplyModifiedProperties();
    }

}

public static class SerializedPropertyExtensions
{
    public static bool GetEnum<TEnumType>(this SerializedProperty property, out TEnumType value)
    where TEnumType : System.Enum
    {
        value = default;
        var names = property.enumNames;
        if (names == null || names.Length == 0)
            return false;
        var enumName = names[property.enumValueIndex];
        value = (TEnumType)System.Enum.Parse(typeof(TEnumType), enumName);
        return true;
    }
}