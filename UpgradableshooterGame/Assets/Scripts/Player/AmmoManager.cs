using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public ShopItemSD revolverAmmo;
    public ShopItemSD ak47Ammo;

    void Awake()
    {
        revolverAmmo.currentAmmo = revolverAmmo.maxAmmo; 
        ak47Ammo.currentAmmo = ak47Ammo.maxAmmo;
    }

    
    void Update()
    {
      
    }
}
