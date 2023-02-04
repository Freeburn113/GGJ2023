using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookBehaviour : MonoBehaviour
{
    private CookStates _state;
    private CookStates _targetState;

    [SerializeField] private float moveSpeed = 5.0f;

    [SerializeField] private int customers;
    
    [System.Serializable]
    public struct Destinations { public CookPosts Posts; public Vector3 pos; }
    public Destinations[] destinations;
    private Destinations _destination;

    // Start is called before the first frame update
    void Start()
    {
        _state = CookStates.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case CookStates.IDLE:
                if(customers > 0)
                {
                    _targetState = CookStates.CALLING;
                    _destination = destinations[((int)CookPosts.TELEPHONE)];
                    _state = CookStates.WALKING;
                }

                break;
            case CookStates.WALKING:
                if(Vector3.Distance(transform.position, _destination.pos) > 0.1f)
                {
                    Vector3 dir = _destination.pos - transform.position;
                    dir.Normalize();
                    transform.position += dir * Time.deltaTime * moveSpeed;
                }
                else
                {
                    _state = _targetState;
                }

                break;

            case CookStates.COOKING:

                break;
            case CookStates.SERVING:

                break;
            case CookStates.CALLING:

                break;
        }
    }
}
