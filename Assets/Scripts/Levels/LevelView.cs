using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelName;
    [SerializeField] private GameObject _levelCross;
    
    private LevelObject _thisObject;
    public LevelObject ThisObject => _thisObject;

    public void Init(LevelObject level)
    {
        _thisObject = level;

        _levelName.text = _thisObject.SceneName;
        if(PlayerPrefs.HasKey($"Scene{_thisObject.SceneName}"))
            SetCross();
    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene(_thisObject.SceneName);
    }

    public void SetCross()
    {
        _levelCross.SetActive(true);
    }
}
