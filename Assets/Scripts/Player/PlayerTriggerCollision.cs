using System;
using UnityEngine;

public class PlayerTriggerCollision : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_playerMover.IsJumping == false)
            StartCoroutine(_playerMover.JumpAnimation());
    }
}