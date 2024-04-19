using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crosshair : MonoBehaviour
{
    public float damage = 10;
    public float fireRate = 5;
    private float nextTimeToFire = 0;
    public float range = 100;

    public ParticleSystem muzzleFlash1, muzzleFlash2;
    public GameObject player1, player2, gun1, gun2, groundImpactEffect, enemyImpactEffect;

    public float rotationSpeed = 5f;

    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        //WeaponSwitching.selectedWeapon = gun1.
        if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            ShootingLogic();
        }

        if (PositionSwitch.camManager == 0)
        {
            player1.SetActive(true);
            player2.SetActive(false);
            gun1.SetActive(true);
            gun2.SetActive(false);

            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo2;
            if (Physics.Raycast(ray2, out hitInfo2))
            {
                gun1.transform.LookAt(hitInfo2.point);
            }
        }
        else
        {
            player1.SetActive(false);
            player2.SetActive(true);
            gun1.SetActive(false);
            gun2.SetActive(true); 

            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo2;
            if (Physics.Raycast(ray2, out hitInfo2))
            {
                gun2.transform.LookAt(hitInfo2.point);
            }
        }
    }

    private void ShootingLogic()
    {
        if (PositionSwitch.camManager == 0) muzzleFlash1.Play();
        else muzzleFlash2.Play();

        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                EnemyAi enemyAi = hitInfo.transform.GetComponent<EnemyAi>();
                enemyAi.HP -= enemyAi.shootingDamage;

                Instantiate(enemyImpactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
            else Instantiate(groundImpactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        }
    }
}
