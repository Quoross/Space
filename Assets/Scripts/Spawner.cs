using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject JerryCan;
    public GameObject parachute;
    private int i = 75;

    private void Start()
    {
        bool spawnJerryCan = true; // To alternate between spawning JerryCan and parachute

        while (i > 0)
        {
            var randomSpawn = new Vector3(Random.Range(0, 256), 30, Random.Range(0, 256));

            if (spawnJerryCan)
            {
                Instantiate(JerryCan, randomSpawn, Quaternion.identity);
            }
            else
            {
                Instantiate(parachute, randomSpawn, Quaternion.identity);
            }

            spawnJerryCan = !spawnJerryCan; // Toggle between JerryCan and parachute
            i--;
        }
    }
}
