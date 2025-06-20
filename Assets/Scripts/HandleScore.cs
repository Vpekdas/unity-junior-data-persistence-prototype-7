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
    public List<Player> players;
}

[Serializable]
public class Player
{
    public string name;
    public int score;
}
public class HandleScore : MonoBehaviour
{

    public static HandleScore Instance;
    private Player _player;
    private PlayerList _playerList;
    private string _playerListJson;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        _player = new()
        {
            name = "",
            score = 0
        };
        _playerList = new PlayerList()
        {
            players = new List<Player>()
        };
        _playerListJson = Application.persistentDataPath + "/BestPlayer.json";
        LoadJsonPlayerList();
        DontDestroyOnLoad(gameObject);
    }


    public void SetPlayerScore(int score)
    {
        _player.score = score;
    }

    public void SetPlayerName(string name)
    {
        _player.name = name;
    }

    public int GetPlayerScore()
    {
        return _player.score;
    }

    public string GetPlayerName()
    {
        return _player.name;
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
        if (playerList.players.Count >= 1)
        {
            return playerList.players[0];
        }
        else
        {
            return new Player()
            {
                name = "",
                score = 0,
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
        List<Player> tempList = _playerList.players.Where(p => p != null).ToList();

        Player existing = tempList.FirstOrDefault(p => p.name == player.name);

        if (existing != null)
        {
            if (player.score > existing.score)
            {
                tempList.Remove(existing);
                tempList.Add(player);
            }
        }
        else
        {
            tempList.Add(player);
        }

        tempList = tempList.OrderByDescending(p => p.score).ToList();

        if (tempList.Count > 10)
            tempList = tempList.Take(10).ToList();

        _playerList.players = tempList.ToList();

        SaveIntoJson();
    }



    public PlayerList GetPlayerList()
    {
        return _playerList;
    }
}
