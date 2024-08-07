using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _speed = 3f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;
        _rigidbody.transform.forward = direction;
    }

    public void Stop()
    {
        if (_rigidbody != null)
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
