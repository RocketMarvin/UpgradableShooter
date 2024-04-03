using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float damage = 10;
    public float range = 100;

    Vector2 mouseTurn;

    public ParticleSystem muzzleFlash1, muzzleFlash2;
    public GameObject gun1, gun2, groundImpactEffect, enemyImpactEffect;

    public float rotationSpeed = 5f;

    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootingLogic();
        }

        if (PositionSwitch.camManager == 0)
        {
            gun1.SetActive(true);
            gun2.SetActive(false);

            // Krijg de muispositie op de x- en y-as
            mouseTurn.x += Input.GetAxis("Mouse X");
            mouseTurn.y += Input.GetAxis("Mouse Y");

            // Bereken de rotatie op basis van de muispositie
            float rotationX = -mouseTurn.y * rotationSpeed;
            float rotationY = mouseTurn.x * rotationSpeed;
            Quaternion targetRotation = Quaternion.Euler(rotationX, rotationY, 0f);
            gun1.transform.rotation = targetRotation;
        }
        else
        {
            gun1.SetActive(false);
            gun2.SetActive(true);
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
                enemyAi.HP -= enemyAi.damage;

                Instantiate(enemyImpactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
            else Instantiate(groundImpactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        }
    }
}
