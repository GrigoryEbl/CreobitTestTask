using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if (direction != Vector3.zero)
            _mover.Move(direction);
        else
            _mover.Stop();
    }
}
