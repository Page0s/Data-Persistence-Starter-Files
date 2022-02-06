using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    public bool IsBestScore { get; set; }

    GameData gameData;
    static string newPlayerName;
    static string bestPlayerName;
    static string dataPath = "/gameData.json";
    static int bestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            gameData = new GameData();
            DontDestroyOnLoad(gameObject);

            if (File.Exists(Application.persistentDataPath + dataPath))
            {
                string jsonData = File.ReadAllText(Application.persistentDataPath + dataPath);
                gameData = JsonUtility.FromJson<GameData>(jsonData);
                bestPlayerName = gameData.playerName;
                bestScore = gameData.bestScore;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerName(string name) => newPlayerName = name;
    public string GetPlayerName() => newPlayerName;
    public string GetBestPlayerName() => bestPlayerName;
    public void SetBestPlayerName(string m_PlayerName) => bestPlayerName = m_PlayerName;
    public void SetBestScore(int m_BestScore) => bestScore = m_BestScore;
    public int GetBestScore() => bestScore;

    private void OnApplicationQuit()
    {
        if (IsBestScore)
        {
            IsBestScore = false;
            gameData.playerName = newPlayerName;
            gameData.bestScore = bestScore;
            string jsonData = JsonUtility.ToJson(gameData);

            File.WriteAllText(Application.persistentDataPath + dataPath, jsonData);
        }
    }


}
