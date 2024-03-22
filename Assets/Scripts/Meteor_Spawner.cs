using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnInterval = 2f;
    public float meteorSpeed = 5f;
    public Vector3 spawnAreaSize = new Vector3(10f, 10f, 10f);
    public float spawnDistanceMin = 5f;
    public float spawnDistanceMax = 20f;
    public LayerMask groundLayer;
    public float gracePeriodDuration = 5f; // Grace period duration in seconds

    private float nextSpawnTime;
    private Transform playerTransform;
    private bool gracePeriodOver = false;

    private void Start()
    {
        playerTransform = transform;
        nextSpawnTime = Time.time + gracePeriodDuration;
    }

    private void Update()
    {
        if (!gracePeriodOver && Time.time >= nextSpawnTime)
        {
            gracePeriodOver = true;
            nextSpawnTime = Time.time + spawnInterval;
        }

        if (gracePeriodOver && Time.time >= nextSpawnTime && !IsPlayerGrounded())
        {
            SpawnMeteor();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private bool IsPlayerGrounded()
    {
        Ray ray = new Ray(playerTransform.position, Vector3.down);
        return Physics.SphereCast(ray, 0.5f, 1.1f, groundLayer);
    }

    private void SpawnMeteor()
    {
        Vector3 playerPosition = playerTransform.position;

        Vector3 spawnPosition = playerPosition +
       new Vector3(
           Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
           Random.Range(spawnDistanceMin, spawnDistanceMax),
           Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
        );

        GameObject newMeteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
        Rigidbody meteorRigidbody = newMeteor.GetComponent<Rigidbody>();

        meteorRigidbody.velocity = (playerPosition - spawnPosition).normalized * meteorSpeed;
        meteorRigidbody.useGravity = true;
    }
}