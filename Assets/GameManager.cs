using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI p1Text;
    public TextMeshProUGUI p2Text;

    private int scoreP1 = 0;
    private int scoreP2 = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ScorePlayer1()
    {
        scoreP1++;
        if (p1Text != null) p1Text.text = scoreP1.ToString();
    }

    public void ScorePlayer2()
    {
        scoreP2++;
        if (p2Text != null) p2Text.text = scoreP2.ToString();
    }
}