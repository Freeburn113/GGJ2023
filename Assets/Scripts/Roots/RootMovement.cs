using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using InteractionSystem;
using UnityEngine;

public class RootMovement : MonoBehaviour, IInteractable
{
    [SerializeField]
    private InteractionType activationType;

    private SplineMesh _splineMesh;

    private float _rootLength;
    private int _pointCount;
    private int _currentPoint = 1;

    public float rootSize = 4.0f;
    public GameObject rootObject;
    public float _sproutchance = 0.3f;

    private SplineComputer _spline;
    private SplinePoint[] _trajectory;
    private SplinePoint[] _points;

    private float _moveAlpha = 0.0f;

    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private Vector3 _targetDestination;
    private Vector3 _currentDestination;

    // Start is called before the first frame update
    void Awake()
    {
        _spline = gameObject.GetComponent<SplineComputer>();

        _splineMesh = GetComponent<SplineMesh>();
        _splineMesh.spline = _spline;

        _rootLength = Vector3.Distance(transform.position, _targetDestination);

        _pointCount = (int)(_rootLength / 3.5f) + 1;
        if(_pointCount < 4) { _pointCount = 4; }

        _trajectory = new SplinePoint[_pointCount];

        for (int i = 0; i < _pointCount; i++)
        {
            _trajectory[i].position = Vector3.Lerp(transform.position, _targetDestination, (float)i / (float)(_pointCount - 1));
            //_trajectory[i].size = Mathf.Lerp(4.0f, 0.0f, (float)i / (float)(_pointCount - 1));
            //_trajectory[i].size *= Mathf.Lerp(1.0f, 2.0f, (float)i / (float)(_pointCount - 1));
            _trajectory[i].size = rootSize;

            if (i != 0 && i != _pointCount - 1)
            {
                _trajectory[i].position += new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            }
        }

        _points = new SplinePoint[2];
        _points[0] = _trajectory[0];
        _points[1] = _trajectory[1];

        _spline.SetPoints(_points);
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentPoint < _pointCount - 1)
        {
            if (_moveAlpha >= 1.0f)
            {
                ++_currentPoint;
                if(Random.Range(0.0f, 1.0f) < _sproutchance)
                {
                    GameObject sprout = Instantiate(rootObject, _trajectory[_currentPoint - 1].position, new Quaternion(0,0,0,0));
                    RootMovement sproutMovement = sprout.GetComponent<RootMovement>();
                    sproutMovement._targetDestination = _trajectory[_currentPoint - 1].position + new Vector3(Random.Range(-rootSize, rootSize), Random.Range(-rootSize, rootSize), Random.Range(-rootSize, rootSize));
                    sproutMovement._sproutchance = _sproutchance - 0.2f;
                    sproutMovement.rootSize = rootSize / 2.0f;
                }
                Debug.Log(_currentPoint);

                _points = new SplinePoint[_currentPoint + 1];
                for (int i = 0; i < _currentPoint + 1; i++)
                {
                    if (i == _currentPoint)
                    {
                        _points[i] = _trajectory[i];
                        _points[i].position = _trajectory[i - 1].position;
                    }
                    else
                    {
                        _points[i] = _trajectory[i];
                    }
                }
                _currentDestination = _trajectory[_currentPoint].position;
                _spline.SetPoints(_points);
                _moveAlpha = 0.0f;
            }
            else
            {
                _moveAlpha += Time.deltaTime * _moveSpeed;
                _points[_currentPoint].position = Vector3.Lerp(_trajectory[_currentPoint - 1].position, _currentDestination, _moveAlpha);
                _spline.SetPoints(_points);
            }
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
