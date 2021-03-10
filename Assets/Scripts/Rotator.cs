using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
   
     public float rotationSpeed = 60f;


    // Update is called once per frame
    void Update()
    {
        //매프레임마다 Y방향으로 60도 회전
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

}
