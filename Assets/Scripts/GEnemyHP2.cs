using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEnemyHP2 : MonoBehaviour
{
    private CharacterController controller;
    private float hp = 75f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Arrow")
        {
           Bullet bullet = other.GetComponent<Bullet>();

           hp -= Bullet.atk;

           if (hp <= 0)
           {
                E_number.enemynumber = E_number.enemynumber - 1;
                gameObject.SetActive(false);
                Destroy(gameObject);
           }
        }
    }
}
