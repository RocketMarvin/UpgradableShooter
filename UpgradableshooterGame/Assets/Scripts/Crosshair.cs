using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public static bool attacked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootingLogic();
    }

    private void ShootingLogic()
    {
        if (Input.GetMouseButtonDown(0) && !attacked)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Enemy"))
                {
                    attacked = true;
                }
            }
        }
        else attacked = false;
    }
}
