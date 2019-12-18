using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov2 : MonoBehaviour {
    //Rigidbody rgd;
    public float vel;
    public float aumento;
    float plus; // para aumentar la velocidad
    public Transform dir;
    public float limit_y;
    public float limit_x;
    public float limit_z;
    Transform pos_padre;
    Vector3 pos_tiburon;
    public Vector3 offset;
    Rigidbody rgd;
  // GvrPointerInputModule point;
    private void Start()
    {
       // pos_padre = GameObject.FindGameObjectWithTag("Control").GetComponent<Transform>();
        plus = 1;
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            rgd = GameObject.FindGameObjectWithTag("Control").GetComponent<Rigidbody>();
        //    pos_tiburon = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        }
        else {
            rgd = gameObject.GetComponent<Rigidbody>();
        }
        
    //    point = GetComponentInChildren<GvrPointerInputModule>();
    }
    // Use this for initialization
    // Update is called once per frame
    void Update() {
        Vector3 direccion = dir.TransformDirection(Vector3.forward);
        float total = vel * plus;
        //print(total + " "+plus+" "+vel);

        //transform.Translate(direccion.normalized * total); //Usar si rigid body falla

        rgd.velocity = direccion.normalized * total;
        //transform.rotation = dir.transform.rotation;
        //SE mueve adelante genio
        if (Mathf.Abs(transform.position.y) > limit_y || Mathf.Abs(transform.position.x) > limit_x || Mathf.Abs(transform.position.z) > limit_z) {
            transform.position = new Vector3(0, 0, 0);
        }
//        movement_all();
    }
  /*  public void movement_all()
    {
        pos_tiburon = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        pos_padre.position = pos_tiburon + offset;
    }*/
    public void predator() {
        plus = aumento;
        print("in");
    }
    public void out_range(){
        plus = 1;
        print("out");
       }
  
}
