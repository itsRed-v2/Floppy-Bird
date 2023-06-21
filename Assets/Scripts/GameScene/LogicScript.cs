using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject startTooltips;
    public GameObject gameOverScreen;
    public GameObject pipeSpawner;
    public AudioSource dingAudio;
    public AudioSource deathAudio;

    [Header("Settings")]
    public float startSpeed;
    public float speedIncreaseRate;
    public float startDistance;
    public float distanceIncreaseRate;

    [Header("GameState")]
    public int score;
    public float gameSpeed;
    public float pipeDistance;
    public float spawnDelay { get; private set; }
    public int highScore {
        get {
            return Persistence.getHighScore();
        }
        set {
            Persistence.setHighscore(value);
            updateHighScoreText();
        }
    }
    private bool gameIsOver = false;
    private bool gameHasStarted = false;

    void Start() {
        updateSpeed();
        updateHighScoreText();
        score = 0;
        updateScoreText();
    }

	void Update() {
        if (!gameHasStarted && Input.GetKeyDown(KeyCode.Space)) {
            StartGame();
        }
    }

    void StartGame() {
        gameHasStarted = true;
        pipeSpawner.SetActive(true);
        startTooltips.SetActive(false);
    }

    public void addScore(int scoreToAdd) {
        if (!gameIsOver) {
            score += scoreToAdd;
            updateScoreText();
            dingAudio.Play();
            updateSpeed();
            if (highScore < score) {
                highScore = score;
            }
        }
    }

    public void updateSpeed() {
        gameSpeed = startSpeed + score * speedIncreaseRate;
        pipeDistance = startDistance + score * distanceIncreaseRate;
        spawnDelay = pipeDistance / gameSpeed;
    }

    public void gameOver() {
        gameIsOver = true;
        gameOverScreen.SetActive(true);
        deathAudio.Play();
    }

    public bool isGameOver() {
        return gameIsOver;
    }

    public bool hasGameStarted() {
        return gameHasStarted;
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void openMainMenu() {
        SceneManager.LoadScene("StartScene");
    }

    private void updateScoreText()
	{
		scoreText.text = score.ToString();
	}

    private void updateHighScoreText() {
        highScoreText.text = "High Score: " + highScore;
    }

}
