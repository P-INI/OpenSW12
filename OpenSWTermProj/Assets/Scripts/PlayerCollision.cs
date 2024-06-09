using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject player;
    public bool Is_Invincible;
    // Start is called before the first frame update
    void Start()
    {
        Is_Invincible = player.GetComponent<Player_Info>().player_Invincible;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(Is_Invincible);
        if (!Is_Invincible)
        {
            Item item = other.GetComponent<Item>();
            if (item != null)
            {
                item.OnPlayerCollision();
                RandomRespawnItem.ItemCount--;
                Destroy(other.gameObject);
            }
        }
    }
}
