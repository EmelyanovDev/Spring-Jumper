using UnityEngine;

public class WaterPusher : MonoBehaviour
{
    [SerializeField] private float _waterForce;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.TryGetComponent(out Water water))
            _rigidbody.AddForce(Vector2.up * _waterForce * Time.deltaTime);
    }
}
