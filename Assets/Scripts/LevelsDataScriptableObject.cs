using UnityEngine;

[CreateAssetMenu(fileName = "LevelsData", menuName = "Custom/Create Levels Data", order = 0)]
public class LevelsDataScriptableObject : ScriptableObject
{
    public LevelData[] LevelsData;
}
