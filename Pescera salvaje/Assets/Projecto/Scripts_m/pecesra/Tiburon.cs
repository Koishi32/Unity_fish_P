using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tiburon : MonoBehaviour {
    public  AudioSource nom;
    public sacarpez llamarfuncionmuerta; //  calls for otrher fish to be produced
    public GameObject sangron; // spwna blood
    public float endtime; //longer means more nom
    Animator PerfectShark;
    GameObject matar;
    public GameObject activar;
    private void Start()
    {
        PerfectShark = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        print(PerfectShark.gameObject.name);
        activar.SetActive(false);
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
                Instantiate(sangron, collision.transform.position, Quaternion.identity);
                llamarfuncionmuerta.muriopez();
                break;
            case "crap_point":
                Destroy(collision.gameObject, 0.8f);
                break;
            case "Enemy":
                print("para");
                this.GetComponent<mov2>().vel = 0;
                activar.SetActive(true);
                //Time.timeScale = 0;
                StartCoroutine("esperar2");
                break;
        }

        

    }
    IEnumerator esperar2()
    {
        
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Main_menu");
    }

}
