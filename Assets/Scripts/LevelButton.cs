using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI indexText;
    [SerializeField] private Button levelButton;
    [SerializeField] private int levelIndex;

    private void Start()
    {
        indexText.text = "level " + levelIndex;

        if (levelIndex == 1 || PlayerPrefs.GetInt("Level" + levelIndex, 0) == 1) levelButton.interactable = true;
        else levelButton.interactable = false;
    }

    public void Play()
    {
        PlayerPrefs.SetInt("CurrentLevel", levelIndex);
        SceneSwitcher.Instance.SwitchToScene("Game");
    }
}
