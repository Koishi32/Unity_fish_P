using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crap_behaiour : MonoBehaviour
{
    public float vel;
    Quaternion Newrotin;
    public float limit_y;
    public float limit_x;
    public float limit_z;
    public Envoment_Mg bajar_basura;
    [SerializeField]
    float  limite_muerte_puntos;
   // Rigidbody myself;
    void Start()
    {
        int aleatorio = Random.Range(3, 12); //basura cambiara de dir de 3 a 12 segs
        transform.rotation = Random.rotation;
        InvokeRepeating("cambiaDir", 4, aleatorio);
        transform.position += new Vector3(0, aleatorio * 1.5f, 0);
        // myself= gameObject.GetComponent<Rigidbody>();
        bajar_basura = GameObject.Find("ADmin").GetComponent<Envoment_Mg>();
    }

    private void Update() // reset position , does rotation and moves fordward
    {
        transform.position += transform.forward * Time.deltaTime * vel;
      //  myself.velocity =  transform.forward.normalized * vel; 
        if (transform.rotation != Newrotin)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Newrotin, Time.deltaTime);
        }
        if (Mathf.Abs(transform.position.y) > limit_y || Mathf.Abs(transform.position.x) > limit_x || Mathf.Abs(transform.position.z) > limit_z)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
    void cambiaDir()
    {
        Newrotin = Random.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera") {
            other.GetComponentInParent<Tiburon>().negativeScore();
            if (other.GetComponentInParent<Tiburon>().Points < limite_muerte_puntos) {
                other.GetComponentInParent<Tiburon>().esta_Perdiendo(false); // Manda mensaje de perdidad pero no por ser pescado
            }
            //GameObject.Find("Player").GetComponent<sacarpez>().pecesMuertos--;
            bajar_basura.actual--;
           Destroy(gameObject);
        }
    }
}
