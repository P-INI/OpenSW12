using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject player;
    public bool Is_Invincible;

    public GameObject GameoverImage;

    public GameObject IngameImage;
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
        if (!Is_Invincible)
        {
            Item item = other.GetComponent<Item_Score>(); // 플레이어가 아이템과 충돌했을 경우
            if (item != null)
            {
                item.OnPlayerCollision(); // 그에 따른 함수 실행 후 삭제
                Destroy(other.gameObject);
            }
            else
            {
                MonsterControll temp = other.GetComponent<MonsterControll>(); // 플레이어가 몬스터와 충돌했을 경우
                if (temp != null)
                {
                    GameObject.Find("@Managers").GetComponent<Managers>().enabled = false; // 게임오버로 판정, 게임오버 화면을 띄우고 게임 정지
                    GameObject.Find("InGameScoreObject").GetComponent<InGameScore>().GameOverScoreText();
                    IngameImage.SetActive(false);
                    GameoverImage.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }
    }
}
