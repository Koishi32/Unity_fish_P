using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour

{
    List<Transform> Posiciones = new List<Transform>();
    public Transform Pos_tiburon; //ENTRE tiburon y submarinos
    GameObject[] temp;
    public float distancia_deteccion;
    public GameObject flecha_activa;
    public float rotation_speed;
    public Transform flecha;
    [SerializeField]
    float minDist;
    // Start is called before the first frame update
    void Start()
    {
        temp = GameObject.FindGameObjectsWithTag("Enemy");
        flecha_activa.SetActive(false);
        foreach (var transformacion in temp)
        {
            Posiciones.Add(transformacion.GetComponent<Transform>());

        }
        temp = null;
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distancia_deteccion);
    }
    // Update is called once per frame
    void Update()
    {
        check_distance();
    }
    void check_distance() {
        Transform cercano = GetClosestEnemy_Index(Posiciones.ToArray());
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(cercano.position - transform.position), rotation_speed * Time.deltaTime);
        //flecha_activa.transform.LookAt(cercano,this.transform.up);
    }
    Transform GetClosestEnemy_Index(Transform[] enemies)
    {
        Transform tMin = null;
         minDist = Mathf.Infinity;
        Vector3 currentPos = Pos_tiburon.position;
        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
            //print(dist);
        }
        if (minDist < distancia_deteccion) //Activa la flecha si el enemigo esta muy cerca
        {
            flecha_activa.SetActive(true);
        }
        else { flecha_activa.SetActive(false); }
        return tMin;

    }
    void tamano(){
        float propro = minDist / distancia_deteccion;
        propro = Mathf.Clamp(1 / propro,0, 1) ;
        flecha.localScale = Vector3.one * propro;
    }
}
