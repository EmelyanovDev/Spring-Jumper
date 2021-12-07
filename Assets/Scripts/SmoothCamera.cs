using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SmoothCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    [Range(0,1)] [SerializeField] private float _cameraSharpness;

    [SerializeField] private Transform _leftBorder, _rightBorder, _bottomBorder;

    private Camera _camera;
    
    private Vector3 _cameraBorders;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        _cameraBorders = _camera.ViewportToWorldPoint(Vector3.one) - transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, _cameraSharpness);

        transform.position = smoothPosition;

        transform.position = new Vector3(
            Mathf.Clamp(
                transform.position.x, 
                _leftBorder.position.x + _cameraBorders.x,
                _rightBorder.position.x - _cameraBorders.x),
            Mathf.Max(transform.position.y, _bottomBorder.position.y + _cameraBorders.y), 
            transform.position.z);
    }
}
