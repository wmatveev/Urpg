using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    public void SetImpulse(Vector2 direction, float force)
    {
        _rigidbody.AddForce( direction * force, (ForceMode)ForceMode2D.Impulse );
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}