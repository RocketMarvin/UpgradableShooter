using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAnimSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShopAnimTrigger()
    {
        GetComponent<Animator>().SetTrigger("ShopSwitch");
    }
}
