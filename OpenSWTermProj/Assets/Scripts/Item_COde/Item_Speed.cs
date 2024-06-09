using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Speed : MonoBehaviour, Item
{
    public float Limit_Time = 3.0f;
    public float Increase_Speed = 8.0f;
    public float speed = 6.0f;
    public float player_speed;
    public bool Increased = false;
    public GameObject player;
    public void OnPlayerCollision()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player_speed = player.GetComponent<Player_Info>().player_speed;
        Increased = true;
        Debug.Log(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Increased)
        {
            if (Limit_Time > 0)
            {
                Limit_Time -= Time.deltaTime;
                player_speed = Increase_Speed;
                Debug.Log(player_speed);
            }
            Increased = false;
            player_speed    = speed;
            Debug.Log(player_speed);
        }
    }
}
