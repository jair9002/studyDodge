using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        //원하는 타입의 컴포넌트를 자신의 게임 오브젝트에서 찾아오는 메서드
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * //Input.GetKey메서드는 키보드의 식별자를 KeyCode 타입으로 입력받습니다
        if(Input.GetKey(KeyCode.UpArrow)== true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed,0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed,0f, 0f);
        }
        */

        // 수평축과 수직축의 입력값을 감지하여 저장
        // GetAxis는 어떤 축에 대한 입력값을 숫자로 반환하는 메서드
        //파라미터 값은 입력 매니저 263p 참조
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        //리지드바디의 속도에 newVelocity 할당
        //velocity 변수는 리지드바디 컴포넌트의 현재 속도를 표현하는 변수
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        //게임 오브젝트는 자신이 추가된 게임 오브젝트를 가리키는 변수
        //게임 오브젝트 비활성화
        gameObject.SetActive(false);
    }

}
