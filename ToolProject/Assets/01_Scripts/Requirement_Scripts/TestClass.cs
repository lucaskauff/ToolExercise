using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestClass : MonoBehaviour
{
    [MenuItem("CONTEXT/TestClass/TestFunction")]
    static void TestFunction()
    {
        Debug.Log("Test text");
    }
}