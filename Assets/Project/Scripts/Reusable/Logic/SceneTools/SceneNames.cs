#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;

public class SceneNameList
{
    public static IReadOnlyCollection<string> GetNames()
    {
        var sceneNames = EditorBuildSettings.scenes.Select(scene =>
        Path.GetFileNameWithoutExtension(scene.path)).ToArray();

        if (sceneNames.Length == 0)
        {
            throw new Exception("Add scenes to \"Scenes in Build\"");
        }

        return sceneNames;
    }
}
#endif