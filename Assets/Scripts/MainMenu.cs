using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{

    public GameObject BackImage;    // 게임방법 화면
    public GameObject Background;   // 초기화면 
    public GameObject GameoverImage;
    public GameObject player;       // PlayMove의 player 
    public CameraControl cameracontrol;       // CameraControl 코드
    public GameObject IngameImage;  // 인게임 화면
    public InGameScore inGamescore; // InGameScore 스크립트를 참조하는 변수

    // Start is called before the first frame update
    void Start()
    {
        BackImage.SetActive(false); // 게임방법 화면 비활성화 
        IngameImage.SetActive(false); // 게임방법 화면 비활성화 
        GameoverImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickNewGame()    // 게임 시작을 눌렀을 때
    {
        Debug.Log("새 게임");
        player.GetComponent<PlayerMove>().enabled = true;
        GameObject.Find("@Managers").GetComponent<Managers>().enabled = true;
        Background.SetActive(false);    // 초기화면 비활성화
        cameracontrol.StartGame();      // CameraControl 코드에서 StratGame() 실행해
        // 시점이 마우스를 쫓아가도록 설정
        IngameImage.SetActive(true);    // 인게임 화면 활성화 
        inGamescore.StartGame();        // 인게임스코어 시작
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

    public void GameOver() // 초기 화면으로 돌아감
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
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