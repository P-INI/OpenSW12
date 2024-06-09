using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { InitInstance(); return s_instance; } } // 적 생성 매니저는 싱글톤 패턴 사용

    static GameObject _player;
    static HashSet<GameObject> _monsters = new HashSet<GameObject>();
    void Start()
    {
        this.enabled = false; // 게임을 시작하기 전엔 비활성화
    }

    void Update()
    {
        if (this.enabled == true) // 최초 1회만 실행, 4방향에 적 생성
        {
            Init(53, 4, 54);
            Init(-53, 4, 54);
            Init(53, 4, -54);
            Init(-53, 4, -54);
            this.enabled = false;
        }
    }

    static void InitInstance() // 싱글톤
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers"); 
            s_instance = go.GetComponent<Managers>();

        }
    }

    static void Init(int x, int y, int z)
    {
        GameObject eneme = Resources.Load<GameObject>("Prefabs/dd"); // 리소스 폴더에서 dd라는 이름의 프리팹 로드
        Vector3 spawnPosition = new Vector3(x, y, z);
        Quaternion spawnRotation = Quaternion.identity;  // 스폰 초기 위치와 각도
        GameObject enemy = Object.Instantiate(eneme, spawnPosition, spawnRotation); // 프리팹에 따라 적 생성
        
        _monsters.Add(enemy);

        _player = GameObject.Find("BoxMan@Stand"); // 플레이어를 찾아놓음
    }

    

}
