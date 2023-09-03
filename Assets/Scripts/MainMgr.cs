using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainMgr : MonoBehaviour
{
    public static MainMgr Instance = null;
    public string playerName;

    public string bestPlayer;
    public int bestScore = 0;


    private void Awake()
    {
        //we dont actually need this if statement because when we are in the Main Scene we cant return to the Start Menu Scene where the Player Data Handle Object already exists.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNewHighScoreAndName();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int bestScore;
    }

    public void SaveNewHighScoreAndName()
    {
        SaveData data = new SaveData();
        data.bestPlayer = bestPlayer;
        data.bestScore = bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadNewHighScoreAndName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.bestPlayer;
            bestScore = data.bestScore;
        }
    }
    
}
