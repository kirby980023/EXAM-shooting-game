using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XXBOSS : MonoBehaviour
{
    public GameObject XXBOSStext;
    public GameObject Joystick;
    public GameObject introduce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
       XXBOSStext.SetActive(false);
       Joystick.SetActive(true);
       introduce.SetActive(false);
       unPause();
    }
        private void unPause()
    {
        Time.timeScale = 1f;
    }
}
