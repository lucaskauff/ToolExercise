using UnityEngine;
using UnityEditor;
using System.IO;

public static class CreateCustomScripts
{
    private const int priority = 81;

    [MenuItem("Assets/Create/UI Script", false, priority)]
    private static void CreateUIScript()
    {
        string templateFilter = ".cs";
        string contains = "UI";
        string fileName = "NewUI.cs";

        CreateScript(templateFilter, contains, fileName);
    }

    private static void CreateScript(string templateFilter, string contains, string fileName)
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (File.Exists(path))
            path = Path.GetDirectoryName(path);
        if (string.IsNullOrEmpty(path)) path = "Assets/";

        string templatePath = FindScriptPath(templateFilter, contains);
        string destName = Path.Combine(path, fileName);

        if (string.IsNullOrEmpty(templatePath)) return;

        CreateScriptAsset(templatePath, destName);

        AssetDatabase.Refresh();
    }

    private static string FindScriptPath(string filter, string contains)
    {
        string[] guids = AssetDatabase.FindAssets(filter);

        foreach (string guid in guids)
        {
            string template = AssetDatabase.GUIDToAssetPath(guid);
            if (template.Contains(contains))
            {
                return template;
            }
        }

        Debug.Log("Template " + contains + " not found, with the filter " + filter);
        return "";
    }

    private static void CreateScriptAsset(string templatePath, string destName)
    {
        typeof(ProjectWindowUtil)
            .GetMethod("CreateScriptAsset", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)
            .Invoke(null, new object[] { templatePath, destName });

    }
}