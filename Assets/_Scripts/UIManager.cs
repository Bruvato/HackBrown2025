using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [Header("Game")]
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _waveBannerText;
    [SerializeField] private TextMeshProUGUI _waveCount;
    [SerializeField] private TextMeshProUGUI _enemyCount;

    public IEnumerator WaveCleared(int waveNumber)
    {
        _waveBannerText.text = "Wave " + waveNumber + " Cleared!";
        _waveBannerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        _waveBannerText.gameObject.SetActive(false);
    }

    public IEnumerator UpdateWave(int waveNumber, int enemyCount)
    {
        _waveBannerText.text = "Wave " + waveNumber;
        _waveBannerText.gameObject.SetActive(true);
        _waveCount.text = "Wave: " + waveNumber;
        _enemyCount.text = enemyCount + " Enemies Remaining...";
        yield return new WaitForSeconds(2f);
        _waveBannerText.gameObject.SetActive(false);
    }

    public void UpdateEnemyCount(int enemyCount)
    {
        _enemyCount.text = enemyCount + " Enemies Remaining...";
    }

}
