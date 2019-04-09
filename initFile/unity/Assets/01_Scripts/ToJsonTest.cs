using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ToJsonTest : MonoBehaviour
{
    public string saveScenePath;
    public string saveGameObjectPath;

    public GameObject[] scenes;
    public GameObject target;

    [ContextMenu("GameObjectToJson")]
    public void GameObjectToJson()
    {
        if (!target) return;

        string filePath = EditorUtility.SaveFolderPanel("save", saveGameObjectPath, "");
        if (filePath == string.Empty) return;
        saveGameObjectPath = filePath + "/"; ;

        GameObjectData data = new GameObjectData(target);
        string json = JsonConvert.SerializeObject(data);
        Util.FileIO.WriteData(json, target.name + ".json", true, saveGameObjectPath);
    }

    [ContextMenu("SceneToJson")]
    public void SceneToJson()
    {

        string filePath = EditorUtility.SaveFolderPanel("save", saveScenePath, "");
        if (filePath == string.Empty) return;      
        saveScenePath = filePath + "/"; ;

        GameObjectData[] sceneDataArr = new GameObjectData[scenes.Length];
        for( int i = 0; i < sceneDataArr.Length; i++ )
        {
            sceneDataArr[i] = new GameObjectData(scenes[i]);
        }

        string json = JsonConvert.SerializeObject(sceneDataArr);
        Util.FileIO.WriteData(json, "scene.json", true, saveScenePath);
    }
}
