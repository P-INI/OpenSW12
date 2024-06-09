using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumppower = 10.0f;
    private Rigidbody playerrigid;
    public Transform cameratrans;
    void Start()
    {
        playerrigid = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float xinput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical");
        Vector3 forward = cameratrans.forward;
        Vector3 right = cameratrans.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
        Vector3 moveDirection = forward * zinput + right * xinput;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        if(Input.GetKeyDown(KeyCode.Space)) if(playerrigid.velocity.y==0) playerrigid.AddForce(new Vector3(0, jumppower, 0), ForceMode.Impulse);
    }
}
