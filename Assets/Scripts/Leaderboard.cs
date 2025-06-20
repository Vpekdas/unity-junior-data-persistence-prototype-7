using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI BestPlayerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerList playerList = HandleScore.Instance.GetPlayerList();
        float offset = 0.0f;
        foreach (Player player in playerList.players)
        {
            if (string.IsNullOrWhiteSpace(player.name)) continue;
            offset -= 40.0f;
            Vector3 pos = BestPlayerText.transform.position + new Vector3(0.0f, offset, 0.0f);
            TextMeshProUGUI playerText = Instantiate(BestPlayerText, pos, BestPlayerText.transform.rotation, BestPlayerText.transform.parent);
            playerText.text = $"Score: {player.name} : {player.score}";
        }
        BestPlayerText.enabled = false;

    }
}
