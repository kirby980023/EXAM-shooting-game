using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBOSS : MonoBehaviour
{
   private float hp = 5f;
    public float speed = 10;
    public Joystick joyStick;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject JS;

    private CharacterController controller;

    private GameObject focusEnemy;
    public string reScene;
    public GameObject win;
    public GameObject winb;
    public GameObject fall;
    public GameObject pause;


    void Start()
    {
        Time.timeScale = 0f;
        controller = GetComponent<CharacterController>();

        // 開始一直射擊的 Coroutine 函式
        StartCoroutine(KeepShooting());
    }

    void Update()
    {
        // 找到最近的一個目標 Enemy 的物件
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        float miniDist = 9999;
        foreach (GameObject enemy in enemys)
        {
            // 計算距離
            float d = Vector3.Distance(transform.position, enemy.transform.position);

            // 跟上一個最近的比較，有比較小就記錄下來
            if (d < miniDist)
            {
                miniDist = d;
                focusEnemy = enemy;
            }
        }



        // 取得方向鍵輸入
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");

        // 取得虛擬搖桿輸入
        float h = joyStick.Horizontal;
        float v = joyStick.Vertical;

        // 合成方向向量
        Vector3 dir = new Vector3(h, 0, v);

        // 調整角色面對方向
        // 判斷方向向量長度是否大於 0.1（代表有輸入）
        if (dir.magnitude > 0.1f)
        {
            // 將方向向量轉為角度
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;

            // 使用 Lerp 漸漸轉向
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }
        else
        {
            // 沒有移動輸入，並且有鎖定的敵人，漸漸面向敵人
            if (focusEnemy)
            {
                var targetRotation = Quaternion.LookRotation(focusEnemy.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
            }
        }

        // 地心引力 (y)
        if (!controller.isGrounded)
        {
            dir.y = -9.8f * 30 * Time.deltaTime;
        }

        // 移動角色位置
        controller.Move(dir * speed * Time.deltaTime);

     if (hp <= 0)
        {
            pause.SetActive(false);
            fall.SetActive(true);
            JS.SetActive(false);
            // Destroy(gameObject);
            Time.timeScale = 0f;
        }

    }

    void Fire()
    {
        // 產生出子彈
        Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
    }


    // 一直射擊的 Coroutine 函式
    IEnumerator KeepShooting()
    {
        while (true)
        {
            // 射擊
            Fire();

            // 暫停 0.5 秒
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        // if (other.tag == "Enemy")
        // {
        //     other.gameObject.SetActive(false);
        //     Destroy(other.gameObject);

        //     GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");

        //     if (objs.Length == 0)
        //     {
        //         SceneManager.LoadScene(nextScene);
        //     }
        // }
        
        if (other.tag == "Sea")
        {
            // fall.SetActive(true);
            SceneManager.LoadScene(reScene);
        }

        if (other.tag == "sword")
        {
            hp -= 1;
            HP_numberBOSS.HPnumber = HP_numberBOSS.HPnumber - 1;
        //    Bullet bullet = other.GetComponent<Bullet>();

        //    hp -= Bullet.atk;
        //    if (hp <= 0)
        //    {
                // gameObject.SetActive(false);
                // Destroy(gameObject);

        //         SceneManager.LoadScene(reScene);
        //    }
        }
   
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");

            if (objs.Length == 0)
            {
                win.SetActive(true);
                winb.SetActive(true);
                JS.SetActive(false);
                pause.SetActive(false);
                Time.timeScale = 0f;
            }
    }
}
