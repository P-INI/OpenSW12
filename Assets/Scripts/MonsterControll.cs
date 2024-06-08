using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterControll : MonoBehaviour
{
    [SerializeField]
    protected Vector3 _destPos;

    [SerializeField]
    protected GameObject _lockTarget;

    State _state;

    public enum State
    { 
        Idle,
        Moving
    }

    private void Start()
    {
        _state = State.Idle;
    }

    void Update()
    {
        switch(_state)
        {
            case State.Idle:
                UpdateIdle(); break;
            case State.Moving:
                UpdateMoving(); break;

        }
    }


    [SerializeField]
    float _scanRange = 10.0f;
    [SerializeField]
    float _attackRange = 2;


    void UpdateIdle()
    {
        GameObject player = GameObject.Find("BoxMan@Stand");
        if (player == null)
            return;
        
        float distance = (player.transform.position - transform.position).magnitude;
        if (distance < _scanRange)
        {
            _lockTarget = player;
            _state = State.Moving;
            return;
        }
    }
    void UpdateMoving()
    {
        if (_lockTarget != null)
        {
            _destPos = _lockTarget.transform.position;
            float distance = (_destPos - transform.position).magnitude;
            if (distance < _attackRange)
            {
                NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
                nma.SetDestination(transform.position);
                return;
            }
        }

        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.5f)
        {
            _state = State.Idle;
            GetComponent<Animator>().SetBool("Moving", true);
        }
        else
        {
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
            nma.SetDestination(_destPos);
            nma.speed = 3;
            GetComponent<Animator>().SetBool("Moving", false);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }
    }
}
