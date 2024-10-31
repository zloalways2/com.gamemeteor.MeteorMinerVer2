using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    [SerializeField] private Slider timerSlider;
    [SerializeField] private Slider failTimerSlider;
    [SerializeField] private Slider winTimerSlider;

    public int TimeLimit { private get; set; }

    public bool IsEnabled { private get; set; } = true;

    private void Start()
    {
        timerSlider.maxValue = failTimerSlider.maxValue = winTimerSlider.maxValue = TimeLimit;
        timerSlider.value = failTimerSlider.value = winTimerSlider.value = TimeLimit;

        if (PlayerPrefs.GetInt("OffTimer", 0) == 1)
        {
            return;
        }

        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => IsEnabled == true);
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => IsEnabled == true);

            TimeLimit -= 1;

            timerSlider.value = TimeLimit;

            if (TimeLimit == 0)
            {
                gameController.Fail();
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public void Disable()
    {
        failTimerSlider.value = winTimerSlider.value = TimeLimit;

        StopAllCoroutines();
    }
}