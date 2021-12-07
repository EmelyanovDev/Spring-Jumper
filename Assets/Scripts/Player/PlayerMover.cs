using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerLogic))]
public class PlayerMover : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private AnimationCurve _jumpAnimationCurve;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private float _jumpForce;

    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _maxDegree;
    
    [SerializeField] private float _minValue;
    [SerializeField] private float _maxValue;
    [SerializeField] private float _jumpDelay;

    [Header("Effects&Music")]
    [SerializeField] private UnityEvent _jumpEffectPlay;

    private PlayerLogic _playerLogic;
    private Rigidbody2D _rigidbody;
    
    private bool _isJumping;

    private float _deltaXPosition;
    private float _startTouchXPosition;

    public bool IsJumping => _isJumping;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerLogic = GetComponent<PlayerLogic>();
    }


    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startTouchXPosition = touch.position.x;
                    break;
                
                case TouchPhase.Moved:
                    _deltaXPosition = _startTouchXPosition - touch.position.x;
                    _startTouchXPosition = touch.position.x;
                    break;
            
                case TouchPhase.Ended:
                    _deltaXPosition = 0;
                    break;
            }
        }
        
        if (_playerLogic.GameIsEnd == false)
        {
            transform.Rotate(0,0, _deltaXPosition * _rotateSpeed * Time.deltaTime);

            if (Mathf.Abs(_rigidbody.rotation) > _maxDegree)
            {
                _playerLogic.Die();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out DeathGround deathGround))
            _playerLogic.Die();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out HydrantWater hydrantWater))
            _rigidbody.AddForce(hydrantWater.transform.rotation * Vector2.up * hydrantWater.PushForce * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out Fire fire))
            _playerLogic.Die();
        
        else if(_playerLogic.GameIsEnd == false && other.gameObject.TryGetComponent(out Finish finish))
            _playerLogic.OnFinishEnter(finish.RewardMoney);
    }

    public IEnumerator JumpAnimation()
    {
        Invoke(nameof(Jump), _jumpDelay);
        
        _isJumping = true;
        
        float currentTime = 0f;
        while (currentTime <= _jumpDuration)
        {
            currentTime += Time.deltaTime;
            var transformLocalScale = transform.localScale;
            transformLocalScale.y = Mathf.Lerp(_minValue,_maxValue,_jumpAnimationCurve.Evaluate(currentTime / _jumpDuration));
            transform.localScale = transformLocalScale;
            yield return null;
        }
        
        _isJumping = false;
    }

    private void Jump()
    {
        _jumpEffectPlay?.Invoke();
        _rigidbody.AddForce(transform.rotation * Vector2.up * _jumpForce);
    }
}
