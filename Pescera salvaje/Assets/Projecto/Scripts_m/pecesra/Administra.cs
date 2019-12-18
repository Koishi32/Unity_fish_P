using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Administra : MonoBehaviour
{
   // public PostProcessingProfile arriba, abajo;
    //PostProcessingBehaviour ProcesPlayer;
    public float maxY;
    Vector3 localizacion_Player;
    public GameObject playerson;
    // Start is called before the first frame update
    void Start()
    {
       /* 
         ProcesPlayer = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<PostProcessingBehaviour>();
        if (ProcesPlayer == null)
        {
            //print("No cacho");
          //  Destroy(this);
        }
        else {
            ProcesPlayer.profile = abajo;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
       /* localizacion_Player = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (localizacion_Player.y > maxY)
        {
            ProcesPlayer.profile = arriba;
        }
        else if (ProcesPlayer.profile != abajo) {
            ProcesPlayer.profile = abajo;
        }*/
       if (Input.GetButtonDown("A")) {
            SceneManager.LoadScene("nv2");
        } else if (Input.GetButtonDown("B"))
        {
            playerson.transform.position = new Vector3(0, -10, 0);
        }
    }
}
