using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    public float distance = 20.0f; // 카메라가 플레이어와 떨어져 있는 거리
    public float Xsensitivity = 4.0f; // X 방향 감도
    public float Ysensitivity = 2.0f; // Y 방향 감도
    public float minYAngle = -20f; // Y 방향 카메라 최소 각도
    public float maxYAngle = 80f; // X 방향 카메라 최소 각도
    public LayerMask obstacleMask; // 카메라와 플레이어 사이 벽이 있는지 체크하기 위한 마스크
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private bool isGameStarted = false; // 게임 시작 여부 확인 변수

    void Start()
    {
        
    }
    void Update()
    {
        if (isGameStarted) // 게임이 시작된 경우에만 카메라 이동
        {
            currentX += Input.GetAxis("Mouse X") * Xsensitivity;
            currentY -= Input.GetAxis("Mouse Y") * Ysensitivity; //마우스의 X,Y변위에 따라 currentX, currentY에 저장
            currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle); // 단, 최대치를 넘지 않도록 클램핑
        }
    }

    void LateUpdate()
    {
        if (isGameStarted) // 게임이 시작된 경우에만 카메라 이동
        {
            Vector3 direction = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0); // 마우스의 움직임에 따라 카메라의 각도 조절
            Vector3 desiredPosition = player.position + rotation * direction; // 플레이어를 바라보도록 목표 위치 설정
            RaycastHit hit;
            if (Physics.Raycast(player.position, desiredPosition - player.position, out hit, distance, obstacleMask))
            {
                desiredPosition = hit.point;
            } // 카메라와 플레이어 사이 벽이 있는지 확인

            transform.position = desiredPosition; // 벽이 있을 시 벽 표면으로 카메라의 위치 조정 > 플레이어는 항상 보이도록
            transform.LookAt(player.position); // 플레이어를 바라보게 조정
        }
    }
    public void StartGame()
    {
        isGameStarted = true;       // MainMenu에서 게임시작 버튼을 누르면 true 로 전환
    }
}
