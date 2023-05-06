using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShowTargetComponent : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private CameraStateController _controller;
    [SerializeField] private float _delay;
    [SerializeField] private UnityEvent _onDelay;

    public void ShowTarget()
    {
        _controller.SetPosition(_target.position);
        _controller.SetState(true);
        Invoke(nameof(MoveBack), _delay);
    }

    private void MoveBack()
    {
        _controller.SetState(false);
        _onDelay?.Invoke();
    }
}
