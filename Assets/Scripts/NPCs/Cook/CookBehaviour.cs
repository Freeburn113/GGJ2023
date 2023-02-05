using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookBehaviour : MonoBehaviour
{
    [SerializeField]
    private CookStates _state;
    [SerializeField]
    private CookStates _targetState;

    [SerializeField] private float moveSpeed = 5.0f;

    [SerializeField] private int customers;
    
    [System.Serializable]
    public struct Destinations { public CookPosts Posts; public Vector3 pos; }
    public Destinations[] destinations;
    private Destinations _destination;

    private bool LockState;

    // Start is called before the first frame update
    void Start()
    {
        _state = CookStates.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        if(LockState) return;
        switch (_state)
        {
            case CookStates.IDLE:
                if (Random.Range(0, 50) < 25)
                {
                    _targetState = CookStates.COOKING;
                    _destination = destinations[((int)CookPosts.CAULDRON)];
                    _state = CookStates.WALKING;
                }
                else
                {
                    _targetState = CookStates.SERVING;
                    _destination = destinations[((int)CookPosts.BAR)];
                    _state = CookStates.WALKING;
                }

                break;
            case CookStates.WALKING:
                if(Vector3.Distance(transform.position, _destination.pos) > 0.1f)
                {
                    transform.LookAt(_destination.pos);
                    Vector3 dir = _destination.pos - transform.position;
                    dir.Normalize();
                    transform.position += dir * (Time.deltaTime * moveSpeed);
                }
                else
                {
                    transform.LookAt(_destination.pos);
                    _state = _targetState;
                }

                break;

            case CookStates.COOKING:
                LockState = true;
                StartCoroutine(WaitAndSecondsAndChangeState(10, CookStates.IDLE, CookPosts.CAULDRON));
                break;
            case CookStates.SERVING:
                transform.LookAt(transform.position + Vector3.back);
                LockState = true;
                StartCoroutine(WaitAndSecondsAndChangeState(5, CookStates.CALLING, CookPosts.TELEPHONE));
                break;
            case CookStates.CALLING:
                transform.LookAt(transform.position + Vector3.back);
                LockState = true;
                StartCoroutine(WaitAndSecondsAndChangeState(10, CookStates.IDLE, CookPosts.BAR));
                break;
        }
    }

    public void NewQuest()
    {
        customers += 1;
        _targetState = CookStates.SERVING;
        _destination = destinations[((int)CookPosts.BAR)];
        _state = CookStates.WALKING;
    }

    public void CompleteQuest()
    {
        customers -= 1;
    }
    
    IEnumerator WaitAndSecondsAndChangeState(float waitTime, CookStates newState, CookPosts post)
    {
        yield return new WaitForSeconds(waitTime);

        _targetState = newState;
        _destination = destinations[((int)post)];
        _state = CookStates.WALKING;
        LockState = false;
    }
    
    IEnumerator WaitAndSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        LockState = false;

    }
    
}
