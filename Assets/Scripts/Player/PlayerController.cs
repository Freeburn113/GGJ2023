using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    
    private CharacterController _controller;
    private Transform _transform;
    private Vector3 _moveDirection;

    private Ray _ray;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _moveDirection.x = horizontal * moveSpeed;
        _moveDirection.z = vertical * moveSpeed;
        
        if (!_controller.isGrounded)
        {
            _moveDirection.y -= 9.8f * Time.deltaTime;
        }
        
        _controller.Move(_moveDirection * Time.deltaTime);

    }
}
