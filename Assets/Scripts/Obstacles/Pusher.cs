using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pusher : MonoBehaviour
{
    [SerializeField] private float _pushForce;
    [SerializeField] private float _destroyDelay;
    private Rigidbody2D _rigidbody;
    private bool _isUsed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isUsed == false)
        {
            if (other.gameObject.TryGetComponent(out PlayerMover playerMover))
            {
                _rigidbody.bodyType = RigidbodyType2D.Dynamic;
                _rigidbody.AddForce(Vector3.up * _pushForce);
                Destroy(gameObject, _destroyDelay);
                _isUsed = true;
            }
        }
        
    }
}
