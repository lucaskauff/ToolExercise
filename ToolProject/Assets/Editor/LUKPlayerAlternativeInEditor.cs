using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LUKPlayerAlternative))]
public class LUKPlayerAlternativeInEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LUKPlayerAlternative playerAlternative = (LUKPlayerAlternative)target;

        playerAlternative.attack = EditorGUILayout.IntSlider("Attack",
            playerAlternative.attack,
            0,
            100
            );
        ProgressBar(playerAlternative.attack / 100f, "Attack");

        playerAlternative.defense = EditorGUILayout.IntSlider("Defense",
            playerAlternative.defense,
            0,
            100
            );
        ProgressBar(playerAlternative.defense / 100f, "Defense");

        bool allowSceneObjects = !EditorUtility.IsPersistent(target);
        playerAlternative.weapon = (GameObject)EditorGUILayout.ObjectField("Weapon Object",
            playerAlternative.weapon,
            typeof(GameObject),
            allowSceneObjects
            );
    }

    void ProgressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }
}