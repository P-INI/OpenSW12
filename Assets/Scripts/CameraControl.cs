using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float cameraspeed = 0.0f;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Sphere");
        cameraspeed = player.GetComponent<PlayerMove>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position + new Vector3(0, 15, -20);
        Vector3 moveVector = new Vector3(dir.x * cameraspeed * Time.deltaTime, dir.y * cameraspeed * Time.deltaTime, dir.z * cameraspeed * Time.deltaTime);
        this.transform.Translate(moveVector);
    }
}
