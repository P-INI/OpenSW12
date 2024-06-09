using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Info : MonoBehaviour
{
    public GameObject player;
    public int player_health;
    public float player_speed;
    public bool player_Invincible;
    // Start is called before the first frame update
    void Start()
    {
        player_Invincible = false;
        player_health = 3;
        player_speed = player.gameObject.GetComponent<PlayerMove>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
