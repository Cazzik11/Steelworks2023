using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float MoveLength;
    public InputController InputController;

    private Rigidbody2D _rigidbody;
    private float _currentMoveLength;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (InputController.IsMoving())
        {
            var speed = MoveLength / InputController.MoveDuration;
            var moveLengthThisFrame = speed * Time.deltaTime;

            if (_currentMoveLength + moveLengthThisFrame >= MoveLength)
            {
                moveLengthThisFrame = MoveLength - _currentMoveLength;
                _currentMoveLength = 0;
            }
            else
            {
                _currentMoveLength += moveLengthThisFrame;
            }

            _rigidbody.MovePosition(_rigidbody.position + InputController.AxisInput * moveLengthThisFrame);
        }
    }
}

