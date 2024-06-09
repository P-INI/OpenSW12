using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    public float distance = 20.0f;
    public float Xsensitivity = 4.0f;
    public float Ysensitivity = 2.0f;
    public float minYAngle = -20f;
    public float maxYAngle = 80f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;

    void Start()
    {
        
    }
    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * Xsensitivity;
        currentY -= Input.GetAxis("Mouse Y") * Ysensitivity;
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
    }

    void LateUpdate()
    {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = player.position + rotation * direction;
        transform.LookAt(player.position);
    }
}
