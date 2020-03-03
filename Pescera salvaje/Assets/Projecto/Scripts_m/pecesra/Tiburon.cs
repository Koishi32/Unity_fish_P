using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tiburon : MonoBehaviour {
    public  AudioSource nom;
    public Transform[] Objetos_Ausar; // Blood [0] activar lose [1] activar letras [2]
    public float offset_z;

    public sacarpez llamarfuncionmuerta; //  calls for otrher fish to be produced
   // public GameObject sangron; // spwna blood
    public float endtime; //longer means more nom
    Animator PerfectShark;
    bool activo_tir;
    float tiempoeje;
    public float TiempoPierde; // Modifcar en editor
    public float Tiempopuntos_muestra;

    private void Start()
    {
       
        PerfectShark = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        print(PerfectShark.gameObject.name);
        Objetos_Ausar[1].position += Vector3.forward * offset_z; //Aparacesa atras
        Objetos_Ausar[2].position +=  Vector3.forward * offset_z; //Aparacesa atras
        activo_tir =true;
        tiempoeje = 0;

    }
    private void OnCollisionEnter(Collision collision)
    {
        string nombre = collision.gameObject.tag;
       /* if (collision.gameObject.tag == "fish") {
            if (nom.isPlaying == false) { //cortamos el audio
                nom.time = 0.6f;
                nom.Play();
                nom.SetScheduledEndTime(AudioSettings.dspTime + (endtime - 0.6f));
            }
            PerfectShark.SetTrigger("mordida");
            print("mordio");
            collision.gameObject.GetComponent<pezmove>().cancel_predator();
            Destroy(collision.gameObject);
            Instantiate(sangron, collision.transform.position, Quaternion.identity);
            llamarfuncionmuerta.muriopez();

        } else if (collision.gameObject.tag == "crap_point") {
            Destroy(collision.gameObject, 0.8f);
        }*/
        switch (nombre) {
            case "fish":
                if (nom.isPlaying == false)
                { //cortamos el audio
                    nom.time = 0.6f;
                    nom.Play();
                    nom.SetScheduledEndTime(AudioSettings.dspTime + (endtime - 0.6f));
                }
                PerfectShark.SetTrigger("mordida");
                print("mordio");
                collision.gameObject.GetComponent<pezmove>().cancel_predator();
                Destroy(collision.gameObject);
                tiempoeje = Tiempopuntos_muestra;
                StartCoroutine("esperar2");
                Objetos_Ausar[2].position -= Vector3.forward * offset_z; //Aparacesa atras
                Instantiate(Objetos_Ausar[0], collision.transform.position, Quaternion.identity); //Activa SANGRE
                llamarfuncionmuerta.muriopez();
                break;
            case "crap_point":
                Destroy(collision.gameObject, 0.8f);
                break;
            case "Enemy":
               // print("para");
                this.GetComponent<mov2>().vel = 0;
                Objetos_Ausar[1].position -= Vector3.forward * offset_z; //Pantalla perdio
                //Time.timeScale = 0;
                activo_tir = false;
                tiempoeje = TiempoPierde;
                StartCoroutine("esperar2");
                break;
        }

        

    }
    IEnumerator esperar2()
    {
        
        yield return new WaitForSeconds(tiempoeje);
        if (activo_tir)
        {
            Objetos_Ausar[2].position += Vector3.forward * offset_z; //Aparacesa atras

        }
        else { SceneManager.LoadScene("Main_menu"); }
       
    }

}
