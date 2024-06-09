using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;       // 점수 출력하는 텍스트 변수
    public TextMeshProUGUI gameoverscoreText;
    public int multiple;    // 시간 당 점수계수
    private int score; // 현재 점수
    private float timer; // 시간 측정을 위한 타이머
    private bool isGameStarted; // 게임 시작 여부

    void Start()
    {
        score = 0;
        timer = 0f;
        isGameStarted = false; // 게임 시작 여부 초기화
        UpdateScoreText();
    }

    void Update()
    {
        if (isGameStarted) // 게임이 시작된 경우에만 점수 증가
        {
            timer += Time.deltaTime; // 타이머 증가

            if (timer >= 1f) // 1초마다 점수 증가
            {
                score += multiple;
                timer = 0f;
                UpdateScoreText();
            }
        }
    }

    public void AddScore(int sc) // 점수 추가
    {
        score += sc;
        UpdateScoreText();
    }

    void UpdateScoreText()      // 갱신된 점수 출력 함수
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOverScoreText()
    {
        gameoverscoreText.text = "Score: " + score.ToString();
    }
    public void StartGame()     // 게임시작 버튼 눌리면 실행되는 함수
    {
        isGameStarted = true;
    }
}