using System;
using System.IO;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager Instance;

    public string CurrentPlayerName;
    public string BestScoreName;
    public int? BestScore;
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    [Serializable]
    class SaveData
    {
        public String BestScoreText;
    }

    public String GetBestScoreText()
    {
        return "Best Score: " + BestScoreName + " : " + BestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData()
        {
            BestScoreText = "Best Score: " + BestScoreName + " : " + BestScore
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            String[] scoreData = data.BestScoreText.Split(":");

            Int32 tempBestScore = -1;

            if (Int32.TryParse(scoreData[2], out tempBestScore))
            {
                BestScore = tempBestScore;
            }

            BestScoreName = scoreData[1];
        }
        else
        {
            BestScore = 0;
            BestScoreName = String.Empty;
        }
    }
}
