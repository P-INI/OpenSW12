using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Item_Score : MonoBehaviour ,Item
{
    public void OnPlayerCollision()
    {
        GameObject.Find("InGameScoreObject").GetComponent<InGameScore>().AddScore(10); // 아이템 획득 시 점수 추가
    }
}
