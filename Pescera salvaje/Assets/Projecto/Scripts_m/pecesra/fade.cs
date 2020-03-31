using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fade : MonoBehaviour
{
     float fade_e;
    public float tiempo_active;
    public float proporcion;
    public SpriteRenderer [] sprites;
    bool permite = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Desaparecer",tiempo_active);
        fade_e = 1;
    }

    private void Update()
    {
        if ( permite)
        {
            fade_e -= Time.deltaTime * proporcion;
            foreach (SpriteRenderer a in sprites) {
                a.color = new Color(1, 1, 1, fade_e);
            }
            if (fade_e <= 0)
            {
                Destroy(this.gameObject);

            }
        }
       
    }
    public void Desaparecer() {

        permite = true;
    }



}
