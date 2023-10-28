using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float MoveLength;
    public InputController InputController;

    private Rigidbody2D _rigidbody;
    private float _currentMoveLength;
    private Vector2 _currentPosition;
    private bool _collision;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentPosition = _rigidbody.position;
    }

    private void OnEnable()
    {
        InputController.OnMoveEnd += EndMove;
    }

    private void OnDisable()
    {
        InputController.OnMoveEnd -= EndMove;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _collision = true;
    }

    private void FixedUpdate()
    {
        if (InputController.IsMoving() && !_collision)
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

    private void EndMove()
    {
        if (_collision)
        {
            _collision = false;
        }
        else
        {
            _currentPosition += InputController.AxisInput.normalized;
            _rigidbody.MovePosition(_currentPosition);
        }
    }
}

