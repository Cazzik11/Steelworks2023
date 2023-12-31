using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float MoveDuration;

    public Action OnMoveEnd;

    private Vector2 _axisInput;
    private float _remainingMoveDuration;

    public Vector2 AxisInput => _axisInput;

    public bool IsMoving()
    {
        return _remainingMoveDuration > 0;
    }

    private void Update()
    {
        _remainingMoveDuration -= Time.deltaTime;

        if (IsMoving())
        {
            return;
        }
        else
        {
            OnMoveEnd?.Invoke();
            _axisInput = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.W))
        {
            _axisInput.y = 1;
            _remainingMoveDuration = MoveDuration;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _axisInput.y = -1;
            _remainingMoveDuration = MoveDuration;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _axisInput.x = -1;
            _remainingMoveDuration = MoveDuration;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _axisInput.x = 1;
            _remainingMoveDuration = MoveDuration;
        }
    }
}
