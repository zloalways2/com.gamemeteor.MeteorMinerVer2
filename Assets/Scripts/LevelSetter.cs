using UnityEngine;

public class LevelSetter : MonoBehaviour
{
    [SerializeField] private LevelsDataScriptableObject levelsData;

    [SerializeField] private ObstaclesSpawner obstaclesSpawner;
    [SerializeField] private Timer timer;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private ScoreCounter scoreCounter;

    private void Start()
    {
        int levelIndex = PlayerPrefs.GetInt("CurrentLevel", 1) - 1;
        timer.TimeLimit = levelsData.LevelsData[levelIndex].TimerLimit;
        obstaclesSpawner.Interval = levelsData.LevelsData[levelIndex].SpawnInterval;
        playerHealth.Health = levelsData.LevelsData[levelIndex].PlayerHP;
        scoreCounter.TargetScore = levelsData.LevelsData[levelIndex].ScoreTarget;
    }
}
