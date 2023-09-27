using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    
   private void OnTriggerEnter(Collider death)
   {
      if (death.CompareTag("Ground"))
      {
         FindObjectOfType<GameManager>().GameOver();
         Debug.Log("death");
      }
   }
}
