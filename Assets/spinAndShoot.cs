using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinAndShoot : MonoBehaviour
{
    public float degreesPerSec = 360f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject psssshh;
    public string inputKey = "v";

    public GameObject player;

    private float bulletForce = 20f;

    private float startSpeed;

    void Start()
    {
        startSpeed = degreesPerSec;
    }

    void Update()
    {
        if (gameController.reset >= 3 && transform.localRotation.z != 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            gameController.reset--;
            degreesPerSec = startSpeed;
        }

        else {
            float rotAmount = degreesPerSec * Time.deltaTime;
            float curRot = transform.localRotation.eulerAngles.z;
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));

            if (Input.GetKeyDown(inputKey) && gameController.playing)
            {
                Shoot();
                degreesPerSec = -1f * degreesPerSec;
            }

            transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
        }
        
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject psh = Instantiate(psssshh, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    
}
