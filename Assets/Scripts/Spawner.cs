using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePattern;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    public float decTime;
    public float minTime = 0.65f;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int random = Random.Range(0, obstaclePattern.Length);
            Instantiate(obstaclePattern[random], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
                startTimeBtwSpawn -= decTime;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
