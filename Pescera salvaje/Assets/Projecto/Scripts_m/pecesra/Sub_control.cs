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
    // Start is called before the first frame update
    void Start()
    {
        rgd_sub = this.GetComponent<Rigidbody>();
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
            //print("quieto");
            rgd_sub.velocity = Vector3.zero;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Maxdist);
    }
}
