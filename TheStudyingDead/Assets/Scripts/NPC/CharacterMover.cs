using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rigidbody;

    private string _directionState = DOWN;
    private Animator _animatorController;

    public const string UP = "Up";
    public const string DOWN = "Down";
    public const string RIGHT = "Right";
    public const string LEFT = "Left";

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }

    public void Move(Vector3 moveDirection)
    {
        if (moveDirection == Vector3.zero)
            Idle();

        _rigidbody.velocity = new Vector2(_moveSpeed * moveDirection.x, _moveSpeed * moveDirection.y);

        if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
        {
            if (moveDirection.x > 0)
            {
                Move(RIGHT);
            }
            else if (moveDirection.x < 0)
            {
                Move(LEFT);
            }
        }
        else
        {
            if (moveDirection.y > 0)
            {
                Move(UP);
            }
            else if (moveDirection.y < 0)
            {
                Move(DOWN);
            }
        }
    }

    public void MoveToPoint()
    {
        //Move(_point.position.normalized);
    }

    private void Move(string direction)
    {
        _animatorController.Play($"Move {direction}");
        _directionState = direction;
    }

    private void Idle()
    {
        _animatorController.Play($"Idle {_directionState}");
    }
}
