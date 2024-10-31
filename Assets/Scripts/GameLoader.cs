using System.Collections;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private SceneSwitcher sceneSwitcher;

    private void Start()
    {
        StartCoroutine(LoadingCoroutine());
    }

    private IEnumerator LoadingCoroutine()
    {
        yield return new WaitForSeconds(5f);
        sceneSwitcher.SwitchToScene("Menu");
    }
}
