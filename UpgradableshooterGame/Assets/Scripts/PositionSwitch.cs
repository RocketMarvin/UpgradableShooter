using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PositionSwitch : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;

    public static int camManager = 0;
    public bool timerBool = false;
    private bool camToggle = false;
    public float cooldown = 5;

    public TextMeshProUGUI cooldownTimer;

    public bool bunkerSwitch = false;
    private void Start()
    {
        camManager = 0;
    }

    public void Update()
    {
        cooldownTimer.text = Mathf.Round(cooldown).ToString();
        if (!timerBool)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                cooldown = 0;
                timerBool = true;
            }
        }
    }
    public void CamSwitch()
    {
        if (cooldown <= 0)
        {
            camToggle = !camToggle;
            GetComponent<Animator>().SetTrigger("Change");
            timerBool = false;
            cooldown = 5;
        }
    }
    
    public void Cam_1()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }
    public void Cam_2()
    {
        camera1.SetActive(false);
        camera2.SetActive(true);
    }

    public void ManageCamera()
    {
        if (camToggle)
        {
            Cam_2();
            camManager = 1;
        }
        else 
        {
            Cam_1();
            camManager = 0;
        }
    }

   
}
