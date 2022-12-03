using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{
    // Déclaration des propriétés
    public GameObject musique;
    public GameObject boutonCommencer;
    public InputField monInputField;
    public Text nomUI;
    public string nom;
    public static bool ddolDejaFait = false;

    void Start()
    {
        boutonCommencer.SetActive(false);

        // Garder la musique
        if (ddolDejaFait == false)
        {
            DontDestroyOnLoad(musique);
            ddolDejaFait = true;
        }
        else
        {
            Destroy(musique);
        }
    }

    void Update()
    {
        // Charger constamment le nom saisi
        nom = (PlayerPrefs.GetString("Nom"));
    }
    public void GestionTexteEntre()
    {
        string texteSaisi = monInputField.text;

        // Saisir le nom et interdir l'accès pour jouer sans nom
        if (texteSaisi != "")
        {
            PlayerPrefs.SetString("Nom", texteSaisi);
            boutonCommencer.SetActive(true);
        }
        else
        {
            texteSaisi = "";
        }
    }

    public void CommencerJeu(string sceneJeu)
    {
        // Changer la scène
        SceneManager.LoadScene("SceneJeu");
    }
}
