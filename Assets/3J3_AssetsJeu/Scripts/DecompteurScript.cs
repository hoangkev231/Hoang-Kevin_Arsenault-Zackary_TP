using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecompteurScript : MonoBehaviour
{
    public int valCompteur = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Compteur", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (valCompteur <= 0)
        {
            CancelInvoke("Compteur");
        }
    }

    void Compteur()
    {
        valCompteur -= 1;
        GetComponent<Text>().text = valCompteur.ToString();
    }
}
