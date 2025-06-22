using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI BestPlayerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerList playerList = HandleScore.s_Instance.GetPlayerList();
        float offset = 0.0f;
        foreach (Player player in playerList.Players)
        {
            if (string.IsNullOrWhiteSpace(player.Name)) continue;
            offset -= 40.0f;
            Vector3 pos = BestPlayerText.transform.position + new Vector3(0.0f, offset, 0.0f);
            TextMeshProUGUI playerText = Instantiate(BestPlayerText, pos, BestPlayerText.transform.rotation, BestPlayerText.transform.parent);
            playerText.text = $"Score: {player.Name} : {player.Score}";
        }
        BestPlayerText.enabled = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
