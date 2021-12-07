using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelsList : MonoBehaviour
{
    [SerializeField] private LevelView _levelTemplate;
    [SerializeField] private LevelObject[] _levelObjects;
    [SerializeField] private Transform _levelContainer;
    private List<LevelView> _levelViews = new List<LevelView>();

    private void Start()
    {
        foreach (var levelObject in _levelObjects)
        {
            CreateLevel(levelObject);
        }
    }

    private void CreateLevel(LevelObject level)
    {
        var createdLevel = Instantiate(_levelTemplate, _levelContainer);
        createdLevel.Init(level);
        _levelViews.Add(createdLevel);
    }
    
    public LevelView GetViewByScene(string sceneName)
    {
        foreach (var levelView in _levelViews)
            if (levelView.ThisObject.SceneName == sceneName)
                return levelView;
        return null;
    }
}
