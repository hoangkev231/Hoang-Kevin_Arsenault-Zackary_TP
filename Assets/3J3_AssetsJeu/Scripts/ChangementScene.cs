using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{
    // D�claration des propri�t�s
    public string nom;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            SceneManager.LoadScene("SceneJeu");
        }
    }

    public void CommencerJeu(string sceneJeu)
    {
        // Changer la sc�ne
        SceneManager.LoadScene("SceneJeu");
    }
}
