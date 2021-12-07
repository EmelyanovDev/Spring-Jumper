using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerMoney))]
public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] private Interface _interface;
    [SerializeField] private LevelsList _levelsList;
    [SerializeField] private GameObject _respawnTouchScreen;
    [SerializeField] private AudioSource _deathSound;
    [SerializeField] private float _pauseDelay;
    private PlayerMoney _playerMoney;
    private Rigidbody2D _rigidbody;
    
    private bool _gameIsEnd;
    public bool GameIsEnd => _gameIsEnd;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerMoney = GetComponent<PlayerMoney>();
    }

    public void OnFinishEnter(int reward)
    {
        _gameIsEnd = true;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.rotation = Quaternion.Euler(0,0,0);

        if (PlayerPrefs.HasKey($"Scene{SceneManager.GetActiveScene().name}") == false)
        {
            _playerMoney.ChangeMoney(reward);
            PlayerPrefs.SetInt($"Scene{SceneManager.GetActiveScene().name}", 1);
            _levelsList.GetViewByScene(SceneManager.GetActiveScene().name).SetCross();
        }
        Invoke(nameof(SetPause), _pauseDelay);
    }
    
    public void Die()
    {
        if (_gameIsEnd) return;
        
        _gameIsEnd = true;
        
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        if(_character.TryGetComponent(out Rigidbody2D rigidbody2D) == false)
            _character.AddComponent<Rigidbody2D>();
        _character.transform.parent = null;
        
        _respawnTouchScreen.SetActive(true);

        if (PlayerPrefs.HasKey("DeathsCount"))
        {
            int deathsCount = PlayerPrefs.GetInt("DeathsCount") + 1;
            PlayerPrefs.SetInt("DeathsCount", deathsCount);
        }
        else
        {
            PlayerPrefs.SetInt("DeathsCount", 1);
        }
        
        _deathSound.Play();
    }

    private void SetPause()
    {
        _interface.PauseButton();
    }
}
