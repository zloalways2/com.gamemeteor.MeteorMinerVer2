using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI winHealthText;
    [SerializeField] private TextMeshProUGUI failHealthText;

    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider failHealthSlider;
    [SerializeField] private Slider winHealthSlider;

    public int Health { private get; set; }

    private bool _canDecreaseHp = true;

    private void Start()
    {
        healthSlider.maxValue = failHealthSlider.maxValue = winHealthSlider.maxValue = Health;
        healthSlider.value = failHealthSlider.value = winHealthSlider.value = Health;

        healthText.text = winHealthText.text = failHealthText.text = Health + "\nHp";

        if (PlayerPrefs.GetInt("InfiniteHP", 0) == 1)
        {
            _canDecreaseHp = false;
            healthText.text = "∞ HP";
        }
    }

    public void DecreaseHealth()
    {
        if (!_canDecreaseHp) return;
        Health -= 1;

        healthSlider.value = failHealthSlider.value = winHealthSlider.value = Health;
        healthText.text = winHealthText.text = failHealthText.text = Health + "\nHp";

        if (Health == 0)
        {
            gameController.Fail();
        }
    }
}
