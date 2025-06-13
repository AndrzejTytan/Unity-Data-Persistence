using System;
using System.IO;
using UnityEngine;

// https://docs.unity3d.com/6000.1/Documentation/ScriptReference/MonoBehaviour.html
public class PersistenceManager : MonoBehaviour {
    private static PersistenceManager instance;
    public static string playerName;
    private static string persistenceFilePath;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        persistenceFilePath = Application.persistentDataPath + "/hiscore.json";
    }

    public class Data {
        public string playerName;
        public int score;
    }

    public static void SaveHighScore(int score) {
        Data data = new Data();
        data.playerName = playerName;
        data.score = score;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(persistenceFilePath, json);
    }

    public static Data LoadHighScore() {
        string json;
        if (File.Exists(persistenceFilePath)) {
            json = File.ReadAllText(persistenceFilePath);
            return JsonUtility.FromJson<Data>(json);
        }

        return null;
    }
}