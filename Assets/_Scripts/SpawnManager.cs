using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    [Header("Game Management")]
    [SerializeField] private GameObject[] _enemies, _bosses;
    [SerializeField] private Transform _enemyContainer, _bossSpawnLoc;
    [SerializeField] private int _enemySpawnTime;

    private bool _canSpawn = false;

    private void Awake()
    {
        Instance = this;
    }

    public void StopSpawning()
    {
        _canSpawn = false;
    }
    public void StartSpawning()
    {
        _canSpawn = true;
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        int waveEnemyTotalCount = GameManager.Instance.GetWaveEnemyTotalCount();
        int enemiesSpawned = 0;
        if(GameManager.Instance.getBossWave())
        {
            GameObject spawnedBoss = Instantiate(_bosses[Random.Range(0, _bosses.Length)], _bossSpawnLoc.position, Quaternion.identity);
            spawnedBoss.transform.parent = _enemyContainer;
            enemiesSpawned++;
        }
        while (_canSpawn)
        {
            Vector3 enemySpawnPos = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10));
            GameObject spawnedEnemy = Instantiate(_enemies[Random.Range(0, _enemies.Length)], enemySpawnPos, Quaternion.identity);

            spawnedEnemy.transform.parent = _enemyContainer;
            enemiesSpawned++;

            if (enemiesSpawned >= waveEnemyTotalCount)
            {
                StopSpawning();
            }

            yield return new WaitForSeconds(_enemySpawnTime);

        }
    }
}
