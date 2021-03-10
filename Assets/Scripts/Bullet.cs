using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트에서 리지드바디 컴포넌트를 찾아 bulletRigidbody 에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.velocity = transform.forward * speed;

        //transform 컴포넌트는 게임 오브젝트의 위치,크기 회전을 담당하는 컴포넌트
        //모든 게임 오브젝트가 하나씩 가지고 있도록 강제됨
        //forward 변수로 게임 오브젝트의 앞쪽 방향 알 수 있었습니다.

        Destroy(gameObject, 3f); //3초 뒤에 파괴 두번째 파라미터가 시간을 의미
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnCollision 계열 함수는 일반적인 콜라이더 가진 두 게임 오브젝트가 충돌할때 자동실행 서로 밀쳐냄
    // OnTrigger 둘 중 하나라도 트리거 콜라이더라면 충돌시 서로 통과

    private void OnTriggerEnter(Collider other)
    {
        //충돌한 상대방 게임 오브젝트가 Player 태그를 가진경우
        if (other.tag == "Player")
        {
            //상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            //상대방 PlayerController 컴포넌트 가져왔다면
            if(playerController != null)
            {
                //다이 실행
                playerController.Die();
            }
        }
    }
}
