using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPickupSocket : MonoBehaviour
{
    [SerializeField] private Transform _lefthand;
    [SerializeField] private Transform _righthand;

    [SerializeField] private Transform _body;

    private Vector3 _offsetdir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(_lefthand.position, _righthand.position, 0.5f);
        transform.rotation = _body.rotation;
        _offsetdir = transform.position - _body.position;
        _offsetdir.y = 0.0f;
        transform.position += _offsetdir;
    }
}
