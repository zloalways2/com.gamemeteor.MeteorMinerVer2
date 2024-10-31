using System;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    [SerializeField] private CustomToggle offTimerToggle;
    [SerializeField] private CustomToggle infiniteHpToggle;

    private void Start()
    {
        if (PlayerPrefs.GetInt("OffTimer", 0) == 0) offTimerToggle.Switch();
        if (PlayerPrefs.GetInt("InfiniteHP", 0) == 0) infiniteHpToggle.Switch();
    }

    public void ToggleInfiniteHP(Boolean value)
    {
        int val = Convert.ToInt32(value);
        PlayerPrefs.SetInt("InfiniteHP", val);
    }

    public void ToggleOffTimer(Boolean value)
    {
        int val = Convert.ToInt32(value);
        PlayerPrefs.SetInt("OffTimer", val);
    }
}
