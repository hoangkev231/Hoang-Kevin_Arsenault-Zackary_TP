using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NomDeConducteur : MonoBehaviour
{
    // Script pour faire apparaître le nom du joueur en-dessous de la scène du jeu.
    // Problème: Ne fonctionne pas
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
