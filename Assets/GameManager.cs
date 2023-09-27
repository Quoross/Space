
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
 public void GameOver()
  {
      if (gameHasEnded==false)
      {
           Debug.Log("Game over");
              gameHasEnded = true;
              Restart();
      }
      
   
  }

 void Restart()
 {
     SceneManager.LoadScene("Level"); // could make this not be hard coded but as of now there is no reason.
 }
}
