using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using TMPro;
using System.IO;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using System.Linq;


[Serializable]
public class PlayerList
{
    public List<Player> Players;
}

[Serializable]
public class Player
{
    public string Name;
    public int Score;
}
public class HandleScore : MonoBehaviour
{

    public static HandleScore s_Instance;
    private Player _player;
    private PlayerList _playerList;
    private string _playerListJson;

    private void Awake()
    {
        if (s_Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        s_Instance = this;
        _player = new()
        {
            Name = "",
            Score = 0
        };
        _playerList = new PlayerList()
        {
            Players = new List<Player>()
        };
        _playerListJson = Application.persistentDataPath + "/BestPlayer.json";
        LoadJsonPlayerList();
        DontDestroyOnLoad(gameObject);
    }


    public void SetPlayerScore(int score)
    {
        _player.Score = score;
    }

    public void SetPlayerName(string name)
    {
        _player.Name = name;
    }

    public int GetPlayerScore()
    {
        return _player.Score;
    }

    public string GetPlayerName()
    {
        return _player.Name;
    }

    public void SaveIntoJson()
    {
        string player = JsonUtility.ToJson(_playerList);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/BestPlayer.json", player);
        Debug.Log("Json saved in the following path: " + Application.persistentDataPath + "/BestPlayer.json");
    }

    public Player ReadJsonAndReturnBestPlayer()
    {
        string json = File.ReadAllText(_playerListJson);
        PlayerList playerList = JsonUtility.FromJson<PlayerList>(json);
        if (playerList.Players.Count >= 1)
        {
            return playerList.Players[0];
        }
        else
        {
            return new Player()
            {
                Name = "",
                Score = 0,
            };
        }
    }

    public void LoadJsonPlayerList()
    {
        string json = File.ReadAllText(_playerListJson);
        _playerList = JsonUtility.FromJson<PlayerList>(json);
    }

    public void AddPlayerInList(Player player)
    {
        List<Player> tempList = _playerList.Players.Where(p => p != null).ToList();

        Player existing = tempList.FirstOrDefault(p => p.Name == player.Name);

        if (existing != null)
        {
            if (player.Score > existing.Score)
            {
                tempList.Remove(existing);
                tempList.Add(player);
            }
        }
        else
        {
            tempList.Add(player);
        }

        tempList = tempList.OrderByDescending(p => p.Score).ToList();

        if (tempList.Count > 10)
            tempList = tempList.Take(10).ToList();

        _playerList.Players = tempList.ToList();

        SaveIntoJson();
    }



    public PlayerList GetPlayerList()
    {
        return _playerList;
    }
}
