using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envoment_Mg : MonoBehaviour
{
    //public float y_maxima_llega_basura;
    public Transform[] posiciones_basura;
    public GameObject[] prefab_basuriento;
    public int limites;
    public int actual;
    public float frecuencio_sacaB;
    // Start is called before the first frame update
    void Start()
    {
        actual = 0;
        //float randomin = Random.Range(1, 3);
        InvokeRepeating("Spamear_basura",2f, frecuencio_sacaB);
    }
    void Spamear_basura() {
        int i = 0;
        for (i = 0; i < posiciones_basura.Length;i++) {
            if (actual < limites) {
                Instantiate(prefab_basuriento[i], posiciones_basura[i].position, Quaternion.identity);
                actual++;
            }
        }
    }

}
