using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public static int selectedWeapon;
    public GameObject[] weapons;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
        selectedWeapon = weapons.Length;
    }

    // Update is called once per frame
    void Update()
    {
        ScrollWeaponSwitch();
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (GameObject weapon in weapons)
        {
            if (i == selectedWeapon) weapon.gameObject.SetActive(true);
            else weapon.gameObject.SetActive(false);
            i++;
        }
    }

    public void ScrollWeaponSwitch()
    {
        Crosshair crosshair = new Crosshair();

        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1) selectedWeapon = 0;
            selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 1) selectedWeapon = transform.childCount - 1;
            selectedWeapon--;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }
}
