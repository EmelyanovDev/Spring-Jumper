using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    private Transform _target;
    [Range(0,1)] [SerializeField] private float _parallaxStrong;

    private void Start()
    {
        _target = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(_target.position.x, transform.position.y, transform.position.z);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, _parallaxStrong);
        transform.position = smoothPosition;
    }
}
