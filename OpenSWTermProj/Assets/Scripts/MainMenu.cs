using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{

    public GameObject BackImage;    // 게임방법 화면
    public GameObject Background;   // 초기화면 
    public GameObject player;       // PlayMove의 player 
    // Start is called before the first frame update
    void Start()
    {
        BackImage.SetActive(false); // 게임방법 화면 비활성화 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickNewGame()    // 게임 시작을 눌렀을 때
    {
        Debug.Log("새 게임");
        player.GetComponent<PlayerMove>().enabled = true;
        Background.SetActive(false);    // 초기화면 비활성화
    }
    public void ChangeHowToPlay()    // 초기화면 비활성화, 게임방법화면 활성화
    {
        Background.SetActive(false);
        BackImage.SetActive(true); 
    }
    public void ChangeScene()    // 초기화면 활성화, 게임방법화면 비활성화
    {
        Background.SetActive(true);
        BackImage.SetActive(false);
    }
    public void OnClickQuit()    // 게임 종료를 눌렀을 때
    {
        Debug.Log("게임 종료");
#if UNITY_EDITOR                // 유니티 에디터에서 종료법
        UnityEditor.EditorApplication.isPlaying = false;
#else                           // 실행파일에서 종료법
        Application.Quit();
#endif
    }

}
