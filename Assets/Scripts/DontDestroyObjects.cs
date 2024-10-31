using UnityEngine;

public class DontDestroyObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;

    private void Start()
    {
        foreach (GameObject obj in objects)
        {
            if (GameObject.Find(obj.name) != null && GameObject.Find(obj.name) != obj)
            {
                Destroy(obj);
                return;
            }
            DontDestroyOnLoad(obj);
        }
    }
}
