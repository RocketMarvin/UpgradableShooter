using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static float playerHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBehaviour();
    }

    private void HealthBehaviour()
    {
        if(playerHealth <= 0)
        {
            print("You dead");
            playerHealth = 0;
        }
    }
}
