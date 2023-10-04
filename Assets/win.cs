
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
  public bool winner = false;
       private void OnTriggerEnter(Collider win)
        {
            if (win.CompareTag("Player"))
            {
                Invoke("winning", 5);
            Debug.Log("win");

            }
            else
            {
                winner = false;
            }
            if(winner== true)
            {
                SceneManager.LoadScene("Win");
            }
        }

         void winning()
         {
             winner = true;
         }

    
}
