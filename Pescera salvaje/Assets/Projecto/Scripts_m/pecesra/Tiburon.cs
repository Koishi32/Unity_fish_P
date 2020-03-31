using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Tiburon : MonoBehaviour {
    public  AudioSource nom;
    public GameObject particula_sangre;
    public RectTransform[] Objetos_Ausar; //  activar lose [0] activar letras [1]  
    [SerializeField]
    RectTransform pos_score_ini;
    [SerializeField]
    RectTransform pos_perdida_ini;
    [SerializeField]
    RectTransform pos_score_fini;
    [SerializeField]
    RectTransform pos_perdida_fini;
    public Administra victo;
    public sacarpez llamarfuncionmuerta; //  calls for otrher fish to be produced
   // public GameObject sangron; // spwna blood

    public float endtime; //longer means more nom
    Animator PerfectShark;
    bool activo_tir;
    float tiempoeje;
    public float TiempoPierde; // Modifcar en editor
    public float Tiempopuntos_muestra;

    [SerializeField]
    float tiempo_destruc; //
    private void Start()
    {
        numero_combos = 0;
        origina_font_size = texto_point_Multiplier.fontSize;
        texto_point_Multiplier.fontSize = 0.001f;// desaparece texto de bonus
        PerfectShark = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        // print(PerfectShark.gameObject.name);
        Objetos_Ausar[0].position = pos_score_ini.position;
        Objetos_Ausar[1].position = pos_perdida_ini.position;
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
                    nom.time = 0.3f;
                    nom.Play();
                    nom.SetScheduledEndTime(AudioSettings.dspTime + (endtime - 0.3f));
                }
                PerfectShark.SetTrigger("mordida");
                print("mordio");
                collision.gameObject.GetComponent<pezmove>().cancel_predator();
                Destroy(collision.gameObject);
                tiempoeje = Tiempopuntos_muestra; // para diferentes usos de las couroutinas
                StartCoroutine("esperar2");
                Objetos_Ausar[1].position= pos_score_fini.position; // Aparece adelante
                Objetos_Ausar[1].GetComponent<TextMeshProUGUI>().color = Color.blue;
                Objetos_Ausar[1].GetComponent<TextMeshProUGUI>().text = mensajes_positivo;
                var particula = Instantiate(particula_sangre, collision.transform.position, Quaternion.identity); //Activa SANGRE
                //Destroy(particula, tiempo_destruc);
                activo = true;   //Mantiene cierto para combos
                llamarfuncionmuerta.muriopez();
                if ((PointsRaise < multiplicador * Limit_bonus) && activo) { // No mejora mas alla del limite y tiene que activar el combo
                    PointsRaise +=  multiplicador; // Por cada pez atrapado se le suma bonus
                    numero_combos++;
                }
                temporizer = 0; // Reinicia el tiempo para combos 
                Points += default_socre + PointsRaise; // se le suma
                // Cambia el texto escrito en la UI 
                
                break;
            case "crap_point":
                Destroy(collision.gameObject, 0.8f);
                break;
            case "Enemy":
                // print("para");
                if (!victo.vitoria) {
                    esta_Perdiendo(true);
                }
                
                break;
        }

        

    }
    [SerializeField]
    float damage_cost;
    public void negativeScore() {
        StartCoroutine("esperar2");
        Objetos_Ausar[1].GetComponent<TextMeshProUGUI>().color = Color.red;
        Objetos_Ausar[1].GetComponent<TextMeshProUGUI>().text = "Ouch";
        Points -= damage_cost; 
        Objetos_Ausar[1].position = pos_score_fini.position;
    }

    public void esta_Perdiendo(bool pesacado) {
        this.GetComponent<mov2>().vel = 0;
        Objetos_Ausar[0].position = pos_perdida_fini.position;//Pantalla perdio
        activo_tir = false;
        tiempoeje = TiempoPierde;
        if (pesacado) {
            Objetos_Ausar[0].GetComponent<TextMeshProUGUI>().text = "PESCADO";
        }
        else{
            Objetos_Ausar[0].GetComponent<TextMeshProUGUI>().text = "INTOXICADO";
        }
        StartCoroutine("esperar2");
    }

    IEnumerator esperar2()
    {
        
        yield return new WaitForSeconds(tiempoeje);
        if (activo_tir)
        {
            Objetos_Ausar[1].position = pos_score_ini.position; //Aparacesa atras
        }
        else { SceneManager.LoadScene("Main_menu"); }
       
    }
    int numero_combos;
    //Set de los scores
    public void Update()
    {
        //esta_Perdiendo();
        text_modifier();
        check_points_text();

        //Objetos_Ausar[1].GetComponent<TextMeshProUGUI>().text = " "+mensajes_positivo;
        
        texto_point_Multiplier.text = " " + (default_socre + PointsRaise);
        texto_point_Total.text = " " + Points;


    }
    public string mensajes_positivo;
    //string mensaje_nagativo;
    void check_points_text() {
        switch (numero_combos) {
            case 0:
                mensajes_positivo = " ";
                break;
            case 1:
                mensajes_positivo = "Crunch";
                break;
            case 2:
                mensajes_positivo = "Rapido";
                break;
            case 3:
                mensajes_positivo = "Come Pez";
                break;
            case 4:
                mensajes_positivo = "Voraz";
                break;
            case 5:
                mensajes_positivo = "Salvaje";
                break;
            case 6:
                mensajes_positivo = "Terror marino";
                break;
            case 7:
                mensajes_positivo = "Megalodon";
                break;


        }
    }
    void text_modifier() {
        if (activo)
            Combo_Fish();
        if (Points > 0)
        { texto_point_Total.color = Color.blue; }
        else
        {
            texto_point_Total.color = Color.red;
        }
    }
    //Seccion para la los combos pez

    [SerializeField]
    float default_socre;
    [SerializeField]
    TextMeshProUGUI texto_point_Multiplier; //Para interfaze
    [SerializeField]
    TextMeshProUGUI texto_point_Total; // Puntaje
    [SerializeField]
    float multiplicador; //Factor , cuanto gana por pez
    public float Points; //
    float PointsRaise;
    //Para el tiempo
    [SerializeField]
    float temporizer;
    [SerializeField]
    float timeLimit; //tiempo limite desde el editor 
    bool activo = false;
    [SerializeField]
    float Limit_bonus; // Maximo de multiplos que Poinsts Raise puede pasar a multiplicador 
    float origina_font_size;
    void Combo_Fish()
    {
            temporizer +=Time.deltaTime;
        if (temporizer >= timeLimit) {
            activo = false;
            texto_point_Multiplier.fontSize = 0.001f;
            temporizer = 0;
            PointsRaise = 0;
            numero_combos = 0;
        } else{
            texto_point_Multiplier.fontSize = origina_font_size;
        }
    }
    [TextArea]
    public string Notes = "Mayor de 7 por fa";
}
