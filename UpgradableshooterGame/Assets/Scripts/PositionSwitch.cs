using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSwitch : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public int camManager = 0;

    public void CamSwitch()
    {
        GetComponent<Animator>().SetTrigger("Change");
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
        if (camManager == 0)
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
