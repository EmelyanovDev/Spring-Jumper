using System;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private LevelsList _levelsList;
    [SerializeField] private CharactersList _charactersList;

    public void OnLevelsButtonClick()
    {
        _levelsList.gameObject.SetActive(!_levelsList.gameObject.activeSelf);
        _charactersList.gameObject.SetActive(false);
    }

    public void OnShopButtonClick()
    {
        _levelsList.gameObject.SetActive(false);
        _charactersList.gameObject.SetActive(!_charactersList.gameObject.activeSelf);
    }
}
