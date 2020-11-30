using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * _speedRotation, 0); 
        float curSpeed = _speed * Input.GetAxis("Vertical");
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        _characterController.Move(curSpeed * forward);
    }
}