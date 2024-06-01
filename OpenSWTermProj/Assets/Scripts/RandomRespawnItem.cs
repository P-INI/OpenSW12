using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRespawnItem : MonoBehaviour
{
    public GameObject rangeObject;//맵의 바닥부분
    public float Time;//아이템 리스폰 시간
    public static int ItemCount;//아이템 현재 갯수
    public int ItemMaxCount;//아이템 최대 갯수
    BoxCollider rangeCollider;
    public GameObject Item;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
        ItemCount = 0;
        ItemMaxCount = 10;
    }

    Vector3 Return_RandomPosition()
    {
  
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPosition = new Vector3(range_X, 1.5f, range_Z);

        return RandomPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        //아이템 최대 갯수 설정
        while (ItemCount<ItemMaxCount)
        {
            yield return new WaitForSeconds(Time);
            ItemCount++;
            GameObject instantItem = Instantiate(Item, Return_RandomPosition(), Quaternion.identity);
        }
    }

}
