using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded;

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            Debug.Log("Game over");
            gameHasEnded = true;
            Restart();
        }
    }

    private static void Restart()
    {
        SceneManager.LoadScene("Game over");
    }
}