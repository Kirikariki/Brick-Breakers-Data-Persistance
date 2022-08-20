using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    public static Persistence Instance;

    public string PlayerName;
    public string HighScorePlayer;
    public int HighScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int HighScore;
    }

    public void SaveHighScore(int highscore)
    {
        if (highscore > HighScore)
        {
            HighScorePlayer = PlayerName;
            HighScore = highscore;

            SaveData data = new();
            data.PlayerName = HighScorePlayer;
            data.HighScore = highscore;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScorePlayer = data.PlayerName;
            HighScore = data.HighScore;
        }
        else
        {
            HighScorePlayer = "---";
            HighScore = 0;
        }
    }
}
