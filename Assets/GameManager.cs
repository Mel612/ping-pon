using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI p1Text;
    public TextMeshProUGUI p2Text;
    public TextMeshProUGUI timeText;

    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;

    public float matchDuration = 60f;

    private int scoreP1 = 0;
    private int scoreP2 = 0;
    private float timeRemaining;
    private bool gameOver = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }
    }

    private void Start()
    {
        Time.timeScale = 1f;
        timeRemaining = matchDuration;
        gameOver = false;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        UpdateTimeText();
    }

    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
                RestartGame();
            return;
        }

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            UpdateTimeText();
            EndGame();
            return;
        }

        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        if (timeText == null) return;

        int totalSeconds = Mathf.CeilToInt(timeRemaining);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        timeText.text = string.Format("<size=55%>TIME</size>\n{0}:{1:00}", minutes, seconds);
    }

    private void EndGame()
    {
        gameOver = true;

        string result;
        if (scoreP1 > scoreP2)
            result = "GANA JUGADOR 1";
        else if (scoreP2 > scoreP1)
            result = "GANA JUGADOR 2";
        else
            result = "EMPATE";

        if (gameOverText != null)
            gameOverText.text = string.Format("GAME OVER\n\n<size=45%>{0}\n{1} - {2}</size>", result, scoreP1, scoreP2);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        scoreP1 = 0;
        scoreP2 = 0;
        if (p1Text != null) p1Text.text = "0";
        if (p2Text != null) p2Text.text = "0";

        timeRemaining = matchDuration;
        gameOver = false;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        UpdateTimeText();

        Time.timeScale = 1f;

        BallController ball = FindFirstObjectByType<BallController>();
        if (ball != null) ball.LaunchBall();
    }

    public void ScorePlayer1()
    {
        if (gameOver) return;
        scoreP1++;
        if (p1Text != null) p1Text.text = scoreP1.ToString();
    }

    public void ScorePlayer2()
    {
        if (gameOver) return;
        scoreP2++;
        if (p2Text != null) p2Text.text = scoreP2.ToString();
    }
}
