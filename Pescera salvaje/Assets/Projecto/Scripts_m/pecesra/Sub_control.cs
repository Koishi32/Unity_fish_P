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
    public float minDist;
    Rigidbody rgd_sub;
    int aleatorio;
    Quaternion Newrotin;
    bool seguir=false;
    public AudioSource sonar;
    // Start is called before the first frame update
    void Start()
    {
        int aleatorio = Random.Range(4, 12);
        int aleatorio2 = Random.Range(15, 30);
        rgd_sub = this.GetComponent<Rigidbody>();
        InvokeRepeating("cambiaDir", 2, aleatorio);
        InvokeRepeating("localizando", 16, aleatorio2);
        seguir = false;
        minDist = Maxdist / 2;
    }

    // Update is called once per frame
    void Update()
    {
        float distnacia = Vector3.Distance(transform.position, tuburon.position);
        if (distnacia < Maxdist || seguir)
        {
            // transform.position += transform.forward * spedd * Time.deltaTime;
            rgd_sub.velocity = transform.forward * spedd;
            //transform.LookAt(tuburon);
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(tuburon.position - transform.position), rotation_speed * Time.deltaTime);
            if (sonar.isPlaying == false && distnacia < minDist)
            { //cortamos el audio
               // sonar.volume = (minDist/distnacia)/100;
                //print(distnacia);
                sonar.Play();
            }
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, minDist);
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
    void localizando() {
        seguir = true;
        StartCoroutine("esperar"); 
    }

    IEnumerator esperar()
    {
        yield return new WaitForSeconds(5f);
        seguir = false;
    }

}
