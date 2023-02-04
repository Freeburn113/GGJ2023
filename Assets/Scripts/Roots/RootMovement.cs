using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using InteractionSystem;
using UnityEngine;

public class RootMovement : MonoBehaviour, IInteractable
{
    [SerializeField]
    private InteractionType activationType;

    private SplineComputer _spline;
    private SplinePoint[] _points;

    private float _moveAlpha = 1.0f;
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _moveDist = 1.0f;
    [SerializeField] private int _maxPoints = 10;
    private Vector3 _direction;
    private Vector3 _destination;

    // Start is called before the first frame update
    void Start()
    {
        _spline = gameObject.GetComponent<SplineComputer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveAlpha >= 1.0f && _spline.GetPoints().Length < _maxPoints)
        {
            _points = new SplinePoint[_spline.GetPoints().Length + 1];
            Debug.Log("added new point");
            for (int i = 0; i < _spline.GetPoints().Length; i++)
            {
                _points[i] = _spline.GetPoints()[i];
            }

            _points[_points.Length - 1].position = _points[_points.Length - 2].position;

            _direction = _points[_points.Length - 1].position - _points[_points.Length - 3].position;
            _direction += new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            _direction.Normalize();
            //_points[_points.Length - 1].position += _direction * 0.001f;

            _points[_points.Length - 1].size = 0.0f;
            //_points[_points.Length - 1].normal = Vector3.up;

            _destination = _points[_points.Length - 1].position + _direction * _moveDist;

            _spline.SetPoints(_points);
            _moveAlpha = 0.0f;
        }
        else
        {
            _moveAlpha += Time.deltaTime * _moveSpeed;
            if(_moveAlpha > 1.0f)
            {
                _moveAlpha = 1.0f;
            }
            _points[_points.Length - 2].size = _moveAlpha;
            _points[_points.Length - 1].SetPosition(Vector3.Lerp(_spline.GetPoints()[_spline.GetPoints().Length - 2].position,_destination,_moveAlpha));
            _spline.SetPoints(_points);
        }
    }

    public bool Interact(InteractionType attemptWithType)
    {
        if (activationType == attemptWithType)
            return true;
        else
            return false;
    }
}
