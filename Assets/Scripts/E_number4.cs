using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_number4 : MonoBehaviour
{
    public static int BOSSHP;
    public Text ShoweBOSSHP;
    // Start is called before the first frame update
    void Start()
    {
      BOSSHP = 200;
   
    }

    // Update is called once per frame
    void Update()
    {
        ShoweBOSSHP.text = BOSSHP.ToString();
    }
}
