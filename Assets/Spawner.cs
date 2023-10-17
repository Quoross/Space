using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject JerryCan;
    private int i = 20;

    private void Start()
    {
        while (i > 0)
        {
            var randomSpawn = new Vector3(Random.Range(0, 256), 30, Random.Range(0, 256));
            Instantiate(JerryCan, randomSpawn, Quaternion.identity);
            i--;
        }
    }
}