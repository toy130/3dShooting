using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnDelay = 1.0f;
    [SerializeField] bool repeatSpawn = false;
    [SerializeField] float repeatInterval = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnAllEnemies();
        if (repeatSpawn)
        {
            InvokeRepeating("SpawnAllEnemies", repeatInterval, repeatInterval);
        }
    }
    public void SpawnAllEnemies()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            Transform point = spawnPoints[i];
            Instantiate(EnemyPrefab, point.position, point.rotation);
            Debug.Log("敵を生成: 位置" + i);
        }
        Debug.Log("合計 " + spawnPoints.Length + " 体");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
