using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }


    [Header("Wave")]
    [SerializeField] private int _currentWave = 1;
    [SerializeField] private int _waveEnemyMultiplier = 10;
    [SerializeField] private int _waveEnemyTotalCount;
    [SerializeField] private int _enemiesRemaining;
    [SerializeField] private bool _isBossWave;



    private void Awake()
    {
        Instance = this;


    }

    private void Start()
    {
        _waveEnemyTotalCount = CalculateEnemyWaveCount();
        _enemiesRemaining = _waveEnemyTotalCount;
        _isBossWave = false;
        StartCoroutine(StartWave());
    }

    private int CalculateEnemyWaveCount()
    {
        if (_currentWave % 3 == 0)
        {
            _isBossWave = true;
            return _currentWave * _waveEnemyMultiplier/5;
        }
        else
        {
            _isBossWave = false;
        }
        return _currentWave * _waveEnemyMultiplier;
    }

    private IEnumerator StartWave()
    {
        StartCoroutine(UIManager.Instance.UpdateWave(_currentWave, _waveEnemyTotalCount));
        yield return new WaitForSeconds(2f);
        SpawnManager.Instance.StartSpawning();

    }

    public void UpdateEnemyCount()
    {
        _enemiesRemaining--;
        UIManager.Instance.UpdateEnemyCount(_enemiesRemaining);

        if (_enemiesRemaining <= 0)
        {
            StartCoroutine(WaveCleared());
        }
    }

    private IEnumerator WaveCleared()
    {
        StartCoroutine(UIManager.Instance.WaveCleared(_currentWave));
        _currentWave++;
        _waveEnemyTotalCount = CalculateEnemyWaveCount();
        _enemiesRemaining = _waveEnemyTotalCount;
        yield return new WaitForSeconds(2f);
        StartCoroutine(StartWave());
    }

    public int GetWaveEnemyTotalCount()
    {
        return _waveEnemyTotalCount;
    }

    public bool getBossWave()
    {
        return _isBossWave;
    }
}
