using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public string playerName;
    public int playerScore;
    public int highScore;
    public string highScoreName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetHighScore()
    {
        if(playerScore > highScore)
        {
            highScore = playerScore;
            highScoreName = playerName;
            UIManager.instance.UpdateHighscoreText();
        }
    }

    public class HighScoreData
    {
        public int highScore;
        public string name;
    }

    public void SaveHighScore()
    {
        HighScoreData hsData = new HighScoreData();
        hsData.highScore = highScore;
        hsData.name = highScoreName;

        string json = JsonUtility.ToJson(hsData);

        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData hsData = JsonUtility.FromJson<HighScoreData>(json);
            highScore = hsData.highScore;
            highScoreName = hsData.name;
        }
        
    }
}
