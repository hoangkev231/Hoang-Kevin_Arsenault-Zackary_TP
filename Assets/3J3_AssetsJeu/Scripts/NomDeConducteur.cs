using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NomDeConducteur : MonoBehaviour
{
    // Script pour faire appara�tre le nom du joueur en-dessous de la sc�ne du jeu.
    // Probl�me: Ne fonctionne pas
    string refNom;

    void Start()
    {
        refNom = GetComponent<ChangementScene>().nom;
    }

    void Update()
    {
        GetComponent<Text>().text = refNom.ToString();
    }
}
