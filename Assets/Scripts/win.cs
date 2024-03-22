using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public bool winner;
    public float timeLeft = 5.0f;
    private float initialTimeLeft; // Store the initial time left for resetting

    private void Start()
    {
        initialTimeLeft = timeLeft; // Store the initial time left when the game starts
    }

  

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeLeft -= Time.deltaTime; 
            Debug.Log(timeLeft);
            if (timeLeft <= 0)
            {
                Winning();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeLeft = initialTimeLeft; 
        }
    }

    private void Winning()
    {
        winner = true;
        SceneManager.LoadScene("Win");
    }
}