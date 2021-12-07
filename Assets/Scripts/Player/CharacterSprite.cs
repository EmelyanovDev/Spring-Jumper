using UnityEngine;

public class CharacterSprite : MonoBehaviour
{
    [SerializeField] private CharactersList _charactersList;

    void Start()
    {
        _charactersList.Start();
        _charactersList.SetCharacter(_charactersList.GetViewByNumber(PlayerPrefs.GetInt("SavedCharacter")));
    }
}
