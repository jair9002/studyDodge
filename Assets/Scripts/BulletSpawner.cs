using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f; //최소 생성 주기
    public float spawnRateMax = 3f; // 최대 생성 주기

    private Transform target; //발사할 대상
    private float spawnRate; //생성 주기
    private float timeAfterSpawn; //최근 생성 시점에서 지난 시간


    // Start is called before the first frame update
    void Start()
    {
        //최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;
        //탄알 생성 간격을 spawnrateMin 과 spawnRateMax 사이에서 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정 
        // FindObjectOfType 씬에 있는 모든 오브젝트 조사해서 <> 안에 있는 대상 찾아냄
        target = FindObjectOfType<PlayerController>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        //1초에 60번 실행되는 update에 맞춰 시간 계산을 하는 함수 deltaTime은 1/60 의 값을 가진다
        timeAfterSpawn += Time.deltaTime;
    
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f; //리셋

            //Instantiate 원본 오브젝트를 복제하여 생성하는 메소드
            // Instantiate(원본,위치,회전)
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            //Lookat은 게임 오브젝트의 정면 방향이 target을 향하도록 지정 파라매터형식은 transform
            bullet.transform.LookAt(target);

            //다음번 생성 간격을 Min, Max사이값으로 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        }
    
    }
}
