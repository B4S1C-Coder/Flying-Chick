using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject gameStartScreen;

    private static bool skipStartScreen = false;

    void Start() {
        if (!skipStartScreen) {
            Time.timeScale = 0; // Pause the game
            gameStartScreen.SetActive(true);
        }
    }

    public void StartGame() {
        Time.timeScale = 1;
        gameStartScreen.SetActive(false);
    }

    [ContextMenu("Increase Score")] // This allows us to run this function directly from the editor
    public void AddScore(int toAdd) {
        playerScore += toAdd;
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame() {
        skipStartScreen = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
    }

    public void GameOver() {
        gameOverScreen.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
