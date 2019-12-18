using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBubble : MonoBehaviour
{
    public GameObject[] Blocalidades;
    public sacarpez scripti;
    public GameObject Burbujon;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteAfterTime(3));
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        Blocalidades = scripti.localidades;
        foreach (GameObject a in Blocalidades)
        {
            Instantiate(Burbujon, a.transform.position, Quaternion.Euler(-90f,0f,0f));
        }
    }

}
