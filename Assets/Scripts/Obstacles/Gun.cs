using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _strikePoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _strikeDelay;
    [SerializeField] private float _stikeDistation;

    private void Start()
    {
        StartCoroutine(BulletStrike());
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward ,direction);
    }

    private IEnumerator BulletStrike()
    {
        while (true)
        {
            yield return new WaitForSeconds(_strikeDelay);
            if (Vector3.Distance(transform.position, _target.position) <= _stikeDistation)
            {
                var bullet = Instantiate(_bulletTemplate, _strikePoint.position, transform.rotation);
            }
        }
    }
}
