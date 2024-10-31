using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI winScoreText;
    [SerializeField] private TextMeshProUGUI failScoreText;

    [SerializeField] private Slider scoreSlider;
    [SerializeField] private Slider failScoreSlider;
    [SerializeField] private Slider winScoreSlider;

    public int TargetScore { private get; set; }

    private int _currentScore;

    private void Start()
    {
        scoreSlider.maxValue = failScoreSlider.maxValue = winScoreSlider.maxValue = TargetScore;
        scoreSlider.value = failScoreSlider.value = winScoreSlider.value = 0;

        winScoreText.text = failScoreText.text = scoreText.text = _currentScore + "/" + TargetScore;
    }

    public void AddScore()
    {
        _currentScore += 1;
        winScoreText.text = failScoreText.text = scoreText.text = "Score\n" + _currentScore + "/" + TargetScore;
        scoreSlider.value = failScoreSlider.value = winScoreSlider.value = _currentScore;

        if (_currentScore == TargetScore)
        {
            gameController.Win();
        }
    }
}
