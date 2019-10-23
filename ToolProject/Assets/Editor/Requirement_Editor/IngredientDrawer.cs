using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Ingredient))]
public class IngredientDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //First thing to do
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, 
            GUIUtility.GetControlID(FocusType.Passive),
            label
            );

        //Save the indent level
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        //Calculate all rects for the properties to draw
        var amountRect = new Rect(position.x, position.y, 30, position.height);
        var unitRect = new Rect(position.x + 35, position.y, 50, position.height);
        var nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

        //Draw fields
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("amount"), GUIContent.none);
        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("unit"), GUIContent.none);
        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);

        //Reset the indent level
        EditorGUI.indentLevel = indent;

        //Do this at the end
        EditorGUI.EndProperty();
    }
}