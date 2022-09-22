using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private SphereCollider coll;
    public float radius;
    public float force;

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().useGravity = true;
        //coll.radius = 30;
    }

    void Exlode()
    {
        Collider[] overlappedCOlliders = Physics.OverlapSphere(transform.position, radius);

        for (int i = 0; i < overlappedCOlliders.Length; i++)
        {
            Rigidbody rb = overlappedCOlliders[i].attachedRigidbody;

            if (rb)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
    }
}
