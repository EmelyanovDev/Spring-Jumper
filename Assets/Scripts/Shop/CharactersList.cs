using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharactersList : MonoBehaviour
{
    [SerializeField] private CharacterObject[] _characters;
    [SerializeField] private CharacterView _characterTemplate;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private SpriteRenderer _characterSprite;

    [SerializeField] private Transform _container;

    [SerializeField] private UnityEvent _characterChoosed;
    [SerializeField] private UnityEvent _characterCanceled;
    
    private List<CharacterView> _characterViews = new List<CharacterView>();
    private CharacterView _temporaryView;

    public void Start()
    {
        if(PlayerPrefs.HasKey("Character0") == false)
            PlayerPrefs.SetInt("Character0", 1);
        
        foreach (var character in _characters)
        {
            CreateCharacter(character);
        }
    }

    private void CreateCharacter(CharacterObject character)
    {
        var currentCharacter = Instantiate(_characterTemplate, _container);
        currentCharacter.Init(character, this);
        _characterViews.Add(currentCharacter);
    }

    public void TryBuyCharacter(CharacterView characterView)
    {
        if (characterView.ThisObject.PriceCount <= _playerMoney.Money)
        {
            PlayerPrefs.SetInt($"Character{characterView.ThisObject.CharacterNumber}", 1);
            _playerMoney.ChangeMoney(-characterView.ThisObject.PriceCount);
            
            characterView.SetBuyedLine();
            SetCharacter(characterView);
        }
        else
        {
            _characterCanceled?.Invoke();
        }
    }

    public void SetCharacter(CharacterView characterView)
    {
        characterView.gameObject.SetActive(false);
        if(_temporaryView != null)
            _temporaryView.gameObject.SetActive(true);
        _temporaryView = characterView;
        _characterSprite.sprite = characterView.ThisObject.CharacterSprite;
        PlayerPrefs.SetInt("SavedCharacter", characterView.ThisObject.CharacterNumber);
        _characterChoosed?.Invoke();
    }

    public CharacterView GetViewByNumber(int number)
    {
        foreach (var characterView in _characterViews)
        {
            if (characterView.ThisObject.CharacterNumber == number)
                return characterView;
        }
        return null;
    }
}
