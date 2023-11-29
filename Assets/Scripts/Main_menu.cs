using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
  public GameObject PauseUi;

  public void PlayGame()
  {
    SceneManager.LoadScene("Level");
  }

  public void QuitGame()
  {
    Debug.Log("Quit");
    Application.Quit();
  }

  public static bool Paused;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (Paused)
        Resume();
      else
        Pause();
    }
  }


  public void Resume()
  {
    PauseUi.SetActive(false);
    Time.timeScale = 1f;
    Paused = false;
  }

  private void Pause()
  {
    PauseUi.SetActive(true);
    Time.timeScale = 0f;
    Paused = true;
  }

  public void LoadMenu()
  {
    SceneManager.LoadScene("Menu");
    Time.timeScale = 1f;
  }
}
