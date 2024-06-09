using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumppower = 10.0f;
    private Rigidbody playerrigid; // 플레이어의 물리엔진
    public Transform cameratrans; // 카메라
    public Animator animator; // 플레이어 애니메이션을 위한 객체
    void Start()
    {
        this.enabled = false;
        playerrigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        float xinput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical"); // 수평, 수직 입력을 받음(키보드 wasd, 방향키 등)
        Vector3 forward = cameratrans.forward;
        Vector3 right = cameratrans.right; // 카메라가 얼마나 회전해있는지를 입력받음
        forward.y = 0;
        right.y = 0; // 단, 수직 방향은 무시하고 정규화
        forward.Normalize();
        right.Normalize();
        Vector3 moveDirection = forward * zinput + right * xinput; // 사용자의 입력에 따라 플레이어를 이동
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        bool isMoving = xinput != 0 || zinput != 0; // 이동 시 애니메이션을 주기 위해 이동 중이지 않은 상태를 감지
        animator.SetBool("Moving", !isMoving); // 이동 중일때와 아닐 때에 따라 애니메이터에 Moving 변수 전달
        if (moveDirection != Vector3.zero) // 이동중일 경우
        {
            Quaternion rot = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot,speed*Time.deltaTime*100); // 플레이어가 항상 전방을 바라보도록 조정
        }
        if(Input.GetKeyDown(KeyCode.Space)) if(Math.Abs(playerrigid.velocity.y)<0.1) playerrigid.AddForce(new Vector3(0, jumppower, 0), ForceMode.Impulse); // 점프
    }
}
