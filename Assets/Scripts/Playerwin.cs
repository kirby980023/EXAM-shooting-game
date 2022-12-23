using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerwin : MonoBehaviour
{
    private float hp = 3f;
    public float speed = 10;
    public Joystick joyStick;

    private CharacterController controller;


    void Start()
    {
        Time.timeScale = 1f;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {



        // 取得方向鍵輸入
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");

        // 取得虛擬搖桿輸入
        float h = joyStick.Horizontal;
        float v = joyStick.Vertical;

        // 合成方向向量
        Vector3 dir = new Vector3(h, 0, v);

        if (dir.magnitude > 0.1f)
        {
            // 將方向向量轉為角度
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;

            // 使用 Lerp 漸漸轉向
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }

        // 地心引力 (y)
        if (!controller.isGrounded)
        {
            dir.y = -9.8f * 30 * Time.deltaTime;
        }

        // 移動角色位置
        controller.Move(dir * speed * Time.deltaTime);


    }
}
