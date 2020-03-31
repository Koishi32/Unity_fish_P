using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Administra : MonoBehaviour
{
    public float max_score;
    public Tiburon playerson;
    public RectTransform aviso_win;
    // Start is called before the first frame update
    void Start()
    {
       // playerson = GameObject.FindGameObjectWithTag("Player").GetComponent<Tiburon>();
        aviso_win.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Main_menu") {
            gameOver_return();
        }
        salir();
       
    }
    void salir() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void gameOver_return() {
        if (playerson.Points >= max_score) {
            aviso_win.gameObject.SetActive(true);
            StartCoroutine("esperar");
           // Time.timeScale = 0;
            

        }
    }
    IEnumerator esperar()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
