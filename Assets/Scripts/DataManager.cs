using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static string playerName;
    static int bestScore;
    public static DataManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerName(string name) => playerName = name;

    public string GetPlayerName() => playerName;

    public void SetScore(int score) => bestScore = score;

    public int GetBestScore() => bestScore;
}
