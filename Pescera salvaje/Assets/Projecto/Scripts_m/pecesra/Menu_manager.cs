using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_manager : MonoBehaviour
{
    bool modify;
    public Camera main_cameron;
    public GameObject creditosos;
    public GameObject creditosos2;
    public GameObject menu;
    public GvrReticlePointer punteador;
    //private  texton;
    // Start is called before the first frame update
    void Start()
    {
        GameObject menu_name = GameObject.Find("Menu_Select"); //Will not use anymore
        menu_name.SetActive(true);
        modify = true;
        creditosos.SetActive(false);
        creditosos2.SetActive(false);
        afuera = true;
        continuar = false;
    }
    public float time_limit;
    bool afuera;
    bool continuar;
    string casoso ="nada";
    public void Inicia(string caso)
    {
        casoso = caso;
        if (afuera) {
            afuera = false;
            StartCoroutine("esperar2");
        }

        
    }
    public void Interrumpe() {
        punteador.reset_dia();
        StopCoroutine("esperar2");
        
        afuera = true;
    }
    IEnumerator esperar2()
    {
        yield return new WaitForSeconds(time_limit);
        switch (casoso){
            case "creditos":
                creditos();
                break;
            case "juego":
                carga_inicio();
                break;
            case "salir":
                salir();
                break;
        }
    }


    //Esto se asegura que funcione en el editor con las pruebas de teclado
    public void creditos() {
        if (modify) {
            modify = false;
            creditosos.SetActive(true);
            creditosos2.SetActive(true);
            print("credi");
            //changue canvas
            StartCoroutine("esperar");
            continuar = false;

        }
    }
    public void salir() { //Deberia moriri la aplicacion
      
            print("salir");
   
            Application.Quit();

    }
    public void carga_inicio() {
  
        menu.SetActive(false);
        SceneManager.LoadScene("Menu carga");
        
    }
     void Update()
    {
        /*
        if (Input.GetButtonDown("A") || Input.GetButtonDown("Fire1"))
        {
            //print("XBo");
            Ray raycast = main_cameron.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)); // agara el centro de lo que ve la camara
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                string namae = raycastHit.transform.name;
                print(namae);
                switch (namae)
                {
                    case "START_MENU":
                        SceneManager.LoadScene("nv2");
                        break;
                    case "CREDITS_MENU":
                        print("Ray_cast_succ");
                        break;
                    case "EXIT_MENU":
                        print("salir");
                        Application.Quit();
                        break;
                    default:
                        print("Nada");
                        break;
                }
            }
        }*/
    }
    IEnumerator esperar() {
       yield return new WaitForSeconds(8f);
        creditosos.SetActive(false);
        creditosos2.SetActive(false);
        modify = true;
    }
   
}
