using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "New Level", order = 51)]
public class LevelObject : ScriptableObject
{
    [SerializeField] private string _sceneName;
    public string SceneName => _sceneName;
}
