using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "NewCharacter", order = 51)]
public class CharacterObject : ScriptableObject
{
    [SerializeField] private Sprite _characterSprite;
    public Sprite CharacterSprite => _characterSprite;
    [SerializeField] private int _priceCount;
    public int PriceCount => _priceCount;
    [SerializeField] private int _characterNumber;
    public int CharacterNumber => _characterNumber;
}
