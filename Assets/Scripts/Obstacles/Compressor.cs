using System;
using UnityEngine;

public class Compressor : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateRatio;
    [SerializeField] private bool _rightRotate;

    private Rigidbody2D _rigidbody;
    private int _rotateMultiplier = 1;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (_rightRotate)
            _rotateMultiplier = -1;
    }

    private void FixedUpdate()
    {
        Vector3 position = _rigidbody.position;
        _rigidbody.position += Vector2.right * _speed * Time.deltaTime * _rotateMultiplier;
        _rigidbody.MovePosition(position);
    }

    private void Update()
    {
        float rotate = _speed * Time.deltaTime * _rotateRatio * _rotateMultiplier;
        transform.Rotate(new Vector3(0,0, rotate));
    }
}
