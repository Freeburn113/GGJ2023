using System.Collections.Generic;
using Events.Events;
using Unity.VisualScripting;
using UnityEngine;


public class CustomerBehaviour : MonoBehaviour
{

    [SerializeField]
    private CookStates _state;
    [SerializeField]
    private CookStates _targetState;

    [SerializeField]
    private int _id;
    
    public List<GameObject> Meshes;

    [SerializeField] private float moveSpeed = 5.0f;
    
    [System.Serializable]
    public struct Destinations { public CookPosts Posts; public Vector3 pos; }
    public Destinations[] destinations;
    private Destinations _destination;
        
    void Start()
    {
        _state = CookStates.IDLE;
        
        CustomerEvent.Handlers += CustomerEventHandler;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case CookStates.IDLE:
    
                break;
            case CookStates.WALKING:
                if(Vector3.Distance(transform.position, _destination.pos) > 0.07f)
                {
                    transform.LookAt(_destination.pos);
                    Vector3 dir = _destination.pos - transform.position;
                    dir.Normalize();
                    transform.position += dir * (Time.deltaTime * moveSpeed);
                }
                else
                {
                    //transform.LookAt(_destination.pos);
                    _state = _targetState;
                }
                break;
            case CookStates.CALLING:
                //Entering
                _targetState = CookStates.IDLE;
                switch (_id)
                {
                    case 1:
                        _destination = destinations[(int) CookPosts.SPOT1SEAT];
                        break;
                    case 2:
                        _destination = destinations[(int) CookPosts.SPOT2SEAT];
                        break;
                    case 3:
                        _destination = destinations[(int) CookPosts.SPOT3SEAT];
                        break;
                }
                _state = CookStates.WALKING;
                break;
            case CookStates.COOKING:
                _targetState = CookStates.SERVING;
                switch (_id)
                {
                    case 1:
                        _destination = destinations[(int) CookPosts.SPOT1];
                        break;
                    case 2:
                        _destination = destinations[(int) CookPosts.SPOT2];
                        break;
                    case 3:
                        _destination = destinations[(int) CookPosts.SPOT3];
                        break;
                }
                _state = CookStates.WALKING;
                break;
        }
    }
    
    private void CustomerEventHandler(CustomerEvent e)
    {
        if(e.id != _id) return;
        ActivateMesh(e.meshId);
        EnterBar();
    }

    public void EnterBar()
    {
        _targetState = CookStates.CALLING;
        switch (_id)
        {
            case 1:
                _destination = destinations[(int) CookPosts.SPOT1];
                break;
            case 2:
                _destination = destinations[(int) CookPosts.SPOT2];
                break;
            case 3:
                _destination = destinations[(int) CookPosts.SPOT3];
                break;
        }
        _state = CookStates.WALKING;
    }

    public void LeaveBar()
    {
        
    }
    
    public void ActivateMesh(int index)
    {
        foreach (GameObject mesh in Meshes)
        {
            mesh.SetActive(false);
        }
        Meshes[index].SetActive(true);
    }
}