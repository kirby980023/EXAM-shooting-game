using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    public EnemyStaatus status;
    // public string status;
    public Transform target;

    private NavMeshAgent agent;

    public enum EnemyStaatus
    {
        Idle, Chase1
    }

    void Start()
    {
        // // 目前狀態
        status = EnemyStaatus.Idle;

        // // 導航 AI
        agent = GetComponent<NavMeshAgent>();


    }

    void Update()
    {
        if (status == EnemyStaatus.Idle)
        {
            Idle();

            float d = Vector3.Distance(transform.position, target.transform.position);
            // Debug.Log("Chase 距離：" + d);

            if (d < 6)
            {
                status = EnemyStaatus.Chase1;
                return;
            } 

            Idle();

        }

        if (status == EnemyStaatus.Chase1)
        {
            Chase1();

            float d = Vector3.Distance(transform.position, target.transform.position);
            // Debug.Log("Chase 距離：" + d);

            if (d > 6)
            {
                status = EnemyStaatus.Idle;
            }

            if (target == false)
            {
                status = EnemyStaatus.Idle;
            }

            Chase1();   
        }  
    }
     // 狀態行為：閒置
    private void Idle()
    {

    }

    // 狀態行為：追逐
    private void Chase1()
    {
        agent.SetDestination(target.position);
        agent.SetDestination(target.position);
    }
}