using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;

    public GameObject bullet;
    public GameObject tennis;
    public GameObject granate;
    public static GameObject ammo;


    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        ammo = bullet;
    }

    // Update is called once per frame
    void Update()
    {
        float sideForce = Input.GetAxis("Horizontal") * rotationSpeed;

        if (sideForce != 0.0f)
        {
            body.angularVelocity = new Vector3(0.0f, sideForce, 0.0f);
        }

        float forwardForce = Input.GetAxis("Vertical") * movementSpeed;

        if (forwardForce != 0.0f)
        {
            body.velocity = body.transform.forward * forwardForce;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tennis")
        {
            ammo = tennis;
            Debug.Log($"Орудие заряжено - {ammo.name}");
        }
        if (other.gameObject.tag == "Granate")
        {
            ammo = granate;
            Debug.Log($"Орудие заряжено - {ammo.name}");
        }
        if (other.gameObject.tag == "Ordinary")
        {
            ammo = bullet;
            Debug.Log($"Орудие заряжено - {ammo.name}");
        }
    }
}
