
using UnityEngine;
using UnityEngine.SceneManagement;


public class win : MonoBehaviour
{
    public bool winner;

    public float timeLeft = 5.0f;
    



    private void OnTriggerEnter(Collider win)
    {
        if (win.CompareTag("Player"))
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Invoke(nameof(Winning), 0);
            }
        }
        

        if (winner) SceneManager.LoadScene("Win");
    }

    private void Winning()
    {
        winner = true;
    }
}
