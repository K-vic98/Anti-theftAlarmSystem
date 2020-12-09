using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * _speedRotation, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = _speed * Input.GetAxis("Vertical");
        _characterController.SimpleMove(curSpeed * forward);
    }
}