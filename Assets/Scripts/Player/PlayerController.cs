using System;
using InteractionSystem;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    
    private CharacterController _controller;
    private Transform _transform;
    private Vector3 _moveDirection;

    private Ray _ray;

    private Pickup _heldItem;

    private GameObject _interactable;
    
    [SerializeField]
    private GameObject _model;

    [SerializeField]
    private Transform _pickupSocket;
    [SerializeField] 
    private Transform _handSocket;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        Move();
        
        if(Input.GetKeyDown(KeyCode.E)) Interact();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 

        _moveDirection.x = horizontal * moveSpeed;
        _moveDirection.z = vertical * moveSpeed;

        if (!(horizontal == 0 && vertical == 0))
        {
            _model.transform.LookAt(_transform.position + new Vector3(_moveDirection.x, 0, _moveDirection.z)); 
        }

        if (!_controller.isGrounded)
        {
            _moveDirection.y -= 9.8f * Time.deltaTime;
        }
        
        _controller.Move(_moveDirection * Time.deltaTime);
        
    }

    private void Interact()
    {
        if (_heldItem)
        {
            _heldItem.transform.parent = null;
            _heldItem.TogglePhysics(true);
            _heldItem = null;
            return;
        }
        if (_interactable)
        {
            _interactable.transform.position = _pickupSocket.position;
            _interactable.transform.parent = _pickupSocket.transform;
            _heldItem = _interactable.GetComponent<Pickup>();
            _heldItem.TogglePhysics(false);
            _interactable = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_heldItem) return;
        
        if (null != other.GetComponent<Pickup>())
        {
            _interactable = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_interactable) _interactable = null;
    }
}
