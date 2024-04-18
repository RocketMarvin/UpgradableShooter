using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAnimSwitch : MonoBehaviour
{
    private bool shopToggle = false;
    // Start is called before the first frame update
    void Start()
    {
        shopToggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShopAnimTrigger();
    }

    public void ShopAnimTrigger()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            shopToggle = !shopToggle;

            if (shopToggle) GetComponent<Animator>().SetBool("ShopSwitch", true);
            else GetComponent<Animator>().SetBool("ShopSwitch", false);
        }
    }
}
