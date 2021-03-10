using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject gameOverText;
    public Text timeText;
    public Text recordText;

    private float surviveTime; //생존시간
    private bool isGameover; 

    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("Time Text").GetComponent<Text>();
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            //갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            //게임 오버 상태에서 R 키를 누른 경우
            if(Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene 씬을 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameOverText.SetActive(true);

        //PlayerPrefs는 Player Preference 이라 읽으며 간단한 방식으로 어떤 수치를 로컬(실행 컴퓨터)에
        //저장하고 나중에 다시 불러오는 메서드를 제공하는 유니티 내장클래스
        // 키- 값형태로 저장 PlayerPrefs.SetFloat(string key, string value);
        // 로드 메서드 PlayerPrefs.GetFloat(string key);
        // PlayerPrefs.Haskey(string key) 는 파라미터 키로 저장된 값이 존재하는지 판별하는 bool 함수

        //이전에 저장된 값이 없으면 0할당
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (surviveTime > bestTime)
        {
            //최고 기록값 변경
            bestTime = surviveTime;
            //변경된 최고 기록을 BestTime 키로 저장 
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //최고 기록을 recordText 텍스트 컴포넌트를 이용해 표시
        recordText.text = "Best Time" + (int)bestTime;
    }
}
