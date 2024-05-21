using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumppower = 10.0f;
    private Rigidbody playerrigid;
    void Start()
    {
        playerrigid = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float xinput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical");
        playerrigid.velocity = new Vector3(xinput*speed, playerrigid.velocity.y, zinput*speed);
        if(Input.GetKeyDown(KeyCode.Space)) if(playerrigid.velocity.y==0) playerrigid.AddForce(new Vector3(0, jumppower, 0), ForceMode.Impulse);
    }
}
