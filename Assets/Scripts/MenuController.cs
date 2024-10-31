using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private int levelsAmount;

    public void DeleteProgress()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void UnlockAllLevels()
    {
        for (int i = 1; i <= levelsAmount; i += 1)
        {
            PlayerPrefs.SetInt("Level" + i, 1);
        }
    }
}
