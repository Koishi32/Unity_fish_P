using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class sacarpez : MonoBehaviour
{
    public TextMeshProUGUI puntasos;
    public GameObject [] localidades;
    public GameObject pesacado;
    public int distacia_playerAbs;
    int limite;
    public int max_pez;
    public int pecesMuertos;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        puntasos.text =" ";
        pecesMuertos = 0;
        limite = 0;
        i= 0;
        while (limite < max_pez) // only works once
        {
            i = Random.Range(0, localidades.Length);
            float dis = (localidades[i].transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).magnitude;
            if (Mathf.Abs(dis) > distacia_playerAbs)
            { // No reparace en frente del pez
                Instantiate(pesacado, localidades[i].transform.position, Quaternion.identity);
                limite++;
            }
        }
    }

    public void Update()
    {
        puntasos.text = "Score: " + pecesMuertos;
    }

    public void muriopez() { // Crea otro pez
        limite--;
        pecesMuertos++;
        
        if (limite < max_pez) {
            i = Random.Range(0, localidades.Length);
            float dis = (localidades[i].transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).magnitude;
            if (Mathf.Abs(dis) > distacia_playerAbs)
            { // No reparace en frente del player
                Instantiate(pesacado, localidades[i].transform.position, Quaternion.identity);
                limite++;
            }
        }
    }
}
