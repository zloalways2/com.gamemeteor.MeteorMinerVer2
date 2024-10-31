using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private SceneSwitcher sceneSwitcher;

    [SerializeField] private Timer timer;
    [SerializeField] private ObstaclesSpawner obstaclesSpawner;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject failPanel;
    [SerializeField] private GameObject nextLevelButtonObject;

    [SerializeField] private AudioClip winClip;
    [SerializeField] private AudioClip failClip;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private int maxLevelIndex;

    private int _currentLevelIndex;

    private void Awake()
    {
        Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
        _currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel");

        if (_currentLevelIndex == maxLevelIndex) nextLevelButtonObject.SetActive(false);
    }

    public void Pause()
    {
        Physics2D.simulationMode = SimulationMode2D.Script;
        timer.IsEnabled = obstaclesSpawner.IsEnabled = false;
        playerMovement.enabled = false;
    }

    public void Unpause()
    {
        Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
        timer.IsEnabled = obstaclesSpawner.IsEnabled = true;
        playerMovement.enabled = true;
    }

    public void Win()
    {
        PlayerPrefs.SetInt("Level" + (_currentLevelIndex + 1), 1);
        Pause();
        gamePanel.SetActive(false);
        winPanel.SetActive(true);

        timer.Disable();

        audioSource.PlayOneShot(winClip);
    }

    public void Fail()
    {
        Pause();
        gamePanel.SetActive(false);
        failPanel.SetActive(true);

        timer.Disable();

        audioSource.PlayOneShot(failClip);
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", _currentLevelIndex + 1);
        sceneSwitcher.SwitchToScene("Game");
    }

    public void Retry()
    {
        sceneSwitcher.SwitchToScene("Game");
    }

    public void Menu()
    {
        sceneSwitcher.SwitchToScene("Menu");
    }
}
