using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sub_control : MonoBehaviour
{
    public Transform tuburon;
    public float spedd;
    public float rotation_speed;
    public float Maxdist;
    Rigidbody rgd_sub;
    int aleatorio;
    Quaternion Newrotin;
    // Start is called before the first frame update
    void Start()
    {
        int aleatorio = Random.Range(8, 15);
        rgd_sub = this.GetComponent<Rigidbody>();
        InvokeRepeating("cambiaDir", 2, aleatorio);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(transform.position, tuburon.position) < Maxdist)
        {
            // transform.position += transform.forward * spedd * Time.deltaTime;
            rgd_sub.velocity = transform.forward * spedd;
            //transform.LookAt(tuburon);
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(tuburon.position - transform.position), rotation_speed * Time.deltaTime);
        }
        else {
            Patron_mov();
            rgd_sub.velocity = transform.forward * spedd;

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Maxdist);
    }
    void Patron_mov() {
        if (transform.rotation != Newrotin)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Newrotin, Time.deltaTime);
        }
    }
    void cambiaDir()
    {
        Newrotin = Random.rotation;
    }
}
