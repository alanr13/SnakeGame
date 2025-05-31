using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public int playerScore;
    public TextMeshProUGUI points;

    [ContextMenu("Increase Score")]
    public void AddScore()
    {
        playerScore = playerScore + 1;
        points.text = playerScore.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
