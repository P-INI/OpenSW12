using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class Item_Invincible : MonoBehaviour, Item
{
    public float Limit_Time = 15.0f;
    public bool Is_Invincible;
    public GameObject player;
    public void OnPlayerCollision()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(InvincibleCoroutine(player, Limit_Time));
      
    }

    IEnumerator InvincibleCoroutine(GameObject player,float time)
    {
        player.GetComponent<Player_Info>().player_Invincible = true;
        yield return new WaitForSeconds(time);
        player.GetComponent<Player_Info>().player_Invincible = false;
    }

}

