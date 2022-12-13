using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{
    // Déclaration des propriétés
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
        // Changer la scène
        SceneManager.LoadScene("SceneJeu");
    }
}
