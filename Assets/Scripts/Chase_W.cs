using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase_W : MonoBehaviour
{
    public EnemyStaatus status;
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

            if (d < 5)
            {
                status = EnemyStaatus.Chase1;
                return;
            } 

            if (target == false)
            {
                status = EnemyStaatus.Idle;
            }

            Idle();

        }

        if (status == EnemyStaatus.Chase1)
        {
            Chase1();

            float d = Vector3.Distance(transform.position, target.transform.position);
            // Debug.Log("Chase 距離：" + d);

            if (d > 5)
            {
                status = EnemyStaatus.Idle;
                return;
            }

            if (target == false)
            {
                status = EnemyStaatus.Idle;
                return;
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