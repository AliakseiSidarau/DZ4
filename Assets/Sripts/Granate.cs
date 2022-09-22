using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granate : MonoBehaviour
{
    public float radius = 5f;
    public float force = 700f;
    private float _countdown;
    bool _hasExploded = false;
    [SerializeField] private GameObject _explosionEffect;

    // Update is called once per frame
    //void Update()
    //{
        
       
    //}

    void Explode()
    {
        Instantiate(_explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
           Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
           if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_hasExploded)
        {
            Explode();
            _hasExploded = true;
        }
    }
}
