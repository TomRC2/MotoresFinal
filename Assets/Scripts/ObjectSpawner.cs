using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    AudioSource fuenteaudio;
    public GameObject objectPrefab;
    public float bulletForce;

    private void Start()
    {
        fuenteaudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        { 
         fuenteaudio.Play();
         GameObject bulletClone = Instantiate(objectPrefab, transform.position, transform.rotation);

         Rigidbody bulletRigidBody  = bulletClone.GetComponent<Rigidbody>();

         bulletRigidBody.velocity = transform.up * bulletForce;

            Destroy(bulletClone, 2f);
           
        } 
    }
}
