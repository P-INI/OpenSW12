using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Item_Health : MonoBehaviour ,Item
{
    public void OnPlayerCollision()
    {
        GameObject player = GameObject.FindWithTag("Player");
        int player_health = player.GetComponent<Player_Info>().player_health;
        if (player_health < 3)
            player_health++;
    }
}
