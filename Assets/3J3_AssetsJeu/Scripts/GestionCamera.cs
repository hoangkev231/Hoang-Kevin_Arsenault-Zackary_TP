using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCamera : MonoBehaviour
{
    // Déclaration des propriétés
    public GameObject subaru;
    public GameObject cameraFPS;
    public GameObject camera3ePersonne;
    public GameObject cameraRoueGauche;
    public GameObject cameraRoueDroite;

    void Start()
    {
        Camera.main.gameObject.SetActive(true);
        cameraFPS.SetActive(true);
        camera3ePersonne.SetActive(false);
    }
    void Update()
    {
        // Camera 1 : FPS
        if (Input.GetKeyDown("1"))
        {
            ActiverCamera1(cameraFPS);
        }
        // Camera 2 : 3e personne
        else if (Input.GetKeyDown("2"))
        {
            ActiverCamera2(camera3ePersonne);
        }
        // Camera 3 : Côté gauche
        else if (Input.GetKeyDown("3"))
        {
            ActiverCamera3(cameraRoueGauche);
        }
        // Camera 4 : Côté droite
        else if (Input.GetKeyDown("4"))
        {
            ActiverCamera4(cameraRoueDroite);
        }
    }

    void ActiverCamera1(GameObject cameraFPS)
    {
        Camera.main.gameObject.SetActive(false);
        cameraFPS.SetActive(true);
    }
    void ActiverCamera2(GameObject camera3ePersonne)
    {
        Camera.main.gameObject.SetActive(false);
        camera3ePersonne.SetActive(true);
    }
    void ActiverCamera3(GameObject cameraRoueGauche)
    {
        Camera.main.gameObject.SetActive(false);
        cameraRoueGauche.SetActive(true);
    }
    void ActiverCamera4(GameObject cameraRoueDroite)
    {
        Camera.main.gameObject.SetActive(false);
        cameraRoueDroite.SetActive(true);
    }
}
