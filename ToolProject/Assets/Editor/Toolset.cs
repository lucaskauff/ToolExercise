using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class Toolset : MonoBehaviour
{
    #region Menu Items
    [MenuItem("LUKMenu/Print something")]
    static void PrintSmthg()
    {
        Debug.Log("print test");
    }

    [MenuItem("LUKMenu/Print something with SC #&%a")]
    static void PrintSmthgSC()
    {
        Debug.Log("print test sc");
    }

    [MenuItem("LUKMenu/Look on scene")]
    static void LookOnScene()
    {
        GameObject[] objects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject objTmp in objects)
        {
            Debug.Log("Root object name: " + objTmp.name);
        }
    }

    [MenuItem("LUKMenu/Log selected transform name")]
    static void LogSelectTrans()
    {
        if (Selection.activeTransform != null)
            Debug.Log("Selected transform name: " + Selection.activeTransform.name);
        else
            Debug.LogError("No transform selected!");
    }

    [MenuItem("LUKMenu/Log selected object")]
    static void LogSelectObj()
    {
        if (Selection.activeObject != null)
            Debug.Log("Selected object name: " + Selection.activeObject.name);
        else
            Debug.LogError("No object selected!");
    }

    [MenuItem("LUKMenu/Toggle gameobject active &t")]
    static void ToggleGameobjects()
    {
        foreach (GameObject goTmp in Selection.gameObjects)
        {
            goTmp.SetActive(!goTmp.activeSelf);
        }
    }

    [MenuItem("CONTEXT/Rigidbody/Multiply mass by 4")]
    static void MultiplyMass(MenuCommand command)
    {
        Rigidbody rb = (Rigidbody)command.context;
        rb.mass *= 4;
    }
    #endregion
}