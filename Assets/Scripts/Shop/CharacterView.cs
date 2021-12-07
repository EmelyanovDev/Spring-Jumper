using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private GameObject _buyedLine;
    private CharactersList _charactersList;

    private CharacterObject _thisObject;
    public CharacterObject ThisObject => _thisObject;

    public void Init(CharacterObject thisObject, CharactersList charactersList)
    {
        _charactersList = charactersList;
        _thisObject = thisObject;

        _icon.sprite = _thisObject.CharacterSprite;
        _priceText.text = $"Price:{_thisObject.PriceCount}";
        
        if(PlayerPrefs.HasKey($"Character{_thisObject.CharacterNumber}"))
            SetBuyedLine();
    }

    public void OnButtonClick()
    {
        if (PlayerPrefs.HasKey($"Character{_thisObject.CharacterNumber}")) 
            _charactersList.SetCharacter(this);
        else
            _charactersList.TryBuyCharacter(this);
    }

    public void SetBuyedLine()
    {
        _buyedLine.SetActive(true);
    }
}
