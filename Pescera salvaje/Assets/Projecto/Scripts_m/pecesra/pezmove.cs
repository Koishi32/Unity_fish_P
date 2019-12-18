using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pezmove : MonoBehaviour
{
    public bool can_Send_M;
    public float vel;
   // Vector3 dir;
    public float limit_y;
    public float limit_x;
    public float limit_z;
    public Transform tiburunzon;
    Quaternion Newrotin;
    mov2 function_change;
    public string tag_control;
    MeshCollider colision_m;
    bool actualizar_datos;
    private void Start()
    {
        actualizar_datos = false;
        Invoke("Start_chido", 3);
    }
    void Start_chido()
    {
        can_Send_M = false;
        int aleatorio = Random.Range(3, 12); //Pez cambiara de dir de 3 a 12 segs
        transform.rotation = Random.rotation;
        //function_change = GameObject.FindGameObjectWithTag(tag_control).GetComponent<mov2>();
        
        if (SceneManager.GetActiveScene().name == "Main_menu")
        {

        }
        else {
            function_change = GameObject.FindGameObjectWithTag(tag_control).GetComponentInChildren<mov2>();
            transform.position += new Vector3(aleatorio * 2, 0, 0);
            colision_m = GetComponent<MeshCollider>();
            colision_m.enabled = false;
        }

        // print(function_change.gameObject.name);

        actualizar_datos = true;
        InvokeRepeating("cambiaDir", 4, aleatorio);
    }
    private float Update() // reset position , does rotation and moves fordward
    {
        if (!actualizar_datos) {
            return 4.8f;
        }
        transform.position += transform.forward * Time.deltaTime * vel;
        if (transform.rotation != Newrotin) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Newrotin, Time.deltaTime);
        }
        if (Mathf.Abs(transform.position.y) > limit_y || Mathf.Abs(transform.position.x) > limit_x || Mathf.Abs(transform.position.z) > limit_z)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        if (!(SceneManager.GetActiveScene().name == "Main_menu")) {
            if (tiburunzon != null)
            {
                if (Vector3.Distance(transform.position, tiburunzon.position) < 10)
                {
                    colision_m.enabled = true;
                }
                else
                {
                    colision_m.enabled = false;
                }
            }
            
        }
        return 1;
    }

    public void cancel_predator() {
        if (can_Send_M) {
            print("cancelado");
            function_change.out_range();
            can_Send_M = false;
        }
    }

    public void allow(){
        can_Send_M = true;

    }
    
    void cambiaDir()
    {
        Newrotin = Random.rotation;
    }
}
