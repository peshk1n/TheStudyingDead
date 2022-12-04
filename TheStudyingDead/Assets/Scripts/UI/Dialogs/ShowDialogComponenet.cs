using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Defs/Dialog", fileName = "Dialog")]
public class DialogDef: ScriptableObject
{
    [SerializeField] private DialogData _data;
    public DialogData Data => _data; 
}

public class ShowDialogComponenet : MonoBehaviour
{
    public enum Mode
    {
        Bound, External
    }
    [SerializeField] private Mode _mode;
    [SerializeField] private DialogData _bound;
    [SerializeField] private DialogDef  _external;

    private DialogBoxConntroller _dialogBox;
    public void Show()
    {
        if (_dialogBox == null)
            _dialogBox = FindObjectOfType<DialogBoxConntroller>();
        _dialogBox.ShowDialog(Data);
    }

    public void Show(DialogDef def)
    {
        _external = def;
        Show();
    }

    public DialogData Data
    {
        get
        {
            switch (_mode)
            {
                case Mode.Bound:
                    return _bound;
                case Mode.External:
                    return _external.Data;
                default:
                    throw new ArgumentOutOfRangeException();

            }

        }
    }
}

[CustomEditor(typeof(ShowDialogComponenet))]
public class ShowDialogComponenetEditor: UnityEditor.Editor
{
    private SerializedProperty _modeProperty;

    private void OnEnable()
    {
        _modeProperty = serializedObject.FindProperty("_mode");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(_modeProperty);
        if (_modeProperty.GetEnum(out ShowDialogComponenet.Mode mode))
        {
            switch (mode)
            {
                case ShowDialogComponenet.Mode.Bound:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_bound"));
                    break;
                case ShowDialogComponenet.Mode.External:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("_external"));
                    break;
            }
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