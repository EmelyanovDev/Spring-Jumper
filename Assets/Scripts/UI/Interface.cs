using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField] private Image _pauseButton;
    [SerializeField] private Sprite[] _pauseSprites;
    [SerializeField] private Animator _menuAnimator;
    [SerializeField] private UnityEvent _uISound;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void PauseButton()
    {
        switch (Time.timeScale)
        {
            case 1f:
                SetPause(0f,0, "EndMenuCreate");
                break;
            case 0f:
                SetPause(1f,1, "EndMenuLeave");
                break;
        }
    }

    private void SetPause(float timeScale, int pauseSpriteIndex, string menuAnimationName)
    {
        Time.timeScale = timeScale;
        _pauseButton.sprite = _pauseSprites[pauseSpriteIndex];
        _menuAnimator.Play(menuAnimationName);
        _uISound?.Invoke();
    }
    public void RestartButton()
    {
        _uISound?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
