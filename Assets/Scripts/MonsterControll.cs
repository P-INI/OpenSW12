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

    public enum State // 기본 상태와 움직이는 상태만 존재
    { 
        Idle,
        Moving
    }

    private void Start() // 시작 시 움직이지 않음
    {
        _state = State.Idle;
    }

    void Update()
    {
        switch(_state) // 현재 상태에 따라 서로 다른 동작 실행
        {
            case State.Idle:
                UpdateIdle(); break;
            case State.Moving:
                UpdateMoving(); break;

        }
    }


    [SerializeField]
    float _scanRange = 10.0f; // 플레이어 인식 범위, 에디터에서 300으로 오버라이딩 해놨음
    [SerializeField]
    float _attackRange = 2;


    void UpdateIdle()
    {
        GameObject player = GameObject.Find("BoxMan@Stand"); // 플레이어 탐색
        if (player == null)
            return;
        
        float distance = (player.transform.position - transform.position).magnitude;
        if (distance < _scanRange) // 플레이어와의 거리가 인식 범위보다 작을 경우 플레이어를 타겟으로 설정, Moving 상태로 전환
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
            if (distance < _attackRange) // 플레이어와의 거리가 공격 거리보다 가까울 경우
            {
                NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>(); 
                nma.SetDestination(transform.position);
                return;
            }
        }

        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.5f) // 플레이어와의 거리가 일정 거리 이상 가까워지면 잡은 것으로 인식, Idle로 전환
        {
            _state = State.Idle;
            GetComponent<Animator>().SetBool("Moving", true);
        }
        else // 이외의 경우 AI에 따라 플레이어를 향해 이동
        {
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
            nma.SetDestination(_destPos);
            nma.speed = 20;
            GetComponent<Animator>().SetBool("Moving", false);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }
    }
}
