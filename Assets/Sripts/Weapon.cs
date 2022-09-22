using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject bullet;
    public Transform spawnBullet;

    public float shootForce;
    Vector3 direction = new Vector3(-30f,0f,0f);

    private void Start()
    {
        bullet = RobotControl.ammo;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bullet = RobotControl.ammo;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);
        currentBullet.transform.forward = direction.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
    }
}

