using UnityEngine;

public class WinSpawner : MonoBehaviour
{
    public GameObject WinPlatform;
 
    private int i = 30;

    private void Start()
    {
        while (i > 0)
        {
            var randomSpawn = new Vector3(Random.Range(0, 256), 10, Random.Range(0, 256));
            Instantiate(WinPlatform, randomSpawn, Quaternion.identity);
            i--;
        }
    }
}
