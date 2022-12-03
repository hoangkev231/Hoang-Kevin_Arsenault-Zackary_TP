using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitesseScript : MonoBehaviour
{
    public float valVitesse;
    public GameObject subaru;
    void Start()
    {

    }
    void Update()
    {
        // La "vitesse" ne tient pas compte de la valeur actuelle du déplacement vectorielle de la voiture.

        valVitesse = subaru.GetComponent<DeplacementSubaru>().vitesseAvance;
        valVitesse -= 500f; // La voiture se déplace visiblement lorsque sa vitesse est à 500f.

        if (valVitesse > -1f) // Pour éliminer les valeurs négatives
        {
            GetComponent<Text>().text = (valVitesse * 0.34f).ToString("F0") + " km/h"; // La vitesse est limitée à 170km/h.
        }
        else if (valVitesse < -1000f) // Lorsqu'on recule
        {
            GetComponent<Text>().text = (((valVitesse + 1000f) / 5f) * -1f).ToString("F0") + " km/h"; // On divise par -1f pour avoir un nombre positif.
        }
    }
}
