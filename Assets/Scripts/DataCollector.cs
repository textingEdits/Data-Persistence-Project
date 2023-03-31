using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataCollector : MonoBehaviour
{
    public static DataCollector Instance;
    public string PlayerName;
    public string goldPlayerName;
    public string silverPlayerName;
    public string bronzePlayerName;
    public int PlayerScore;
    public int highScore = 0;
    public int silverScore = 0;
    public int bronzeScore = 0;

    [System.Serializable]
    class Player
    {
        public string PlayerName;
        public int PlayerScore;
    }
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

    public void SavePlayerHighScore()
    {
        Player data = new Player();
        data.PlayerName = PlayerName;
        data.PlayerScore = PlayerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/goldPlayer.json", json);
    }

    public void LoadPlayerHighScore()
    {
        string path = Application.persistentDataPath + "/goldPlayer.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Player data = JsonUtility.FromJson<Player>(json);

            goldPlayerName = data.PlayerName;
            highScore = data.PlayerScore;
        }
        else return;
    }
}
