using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptGenerateurBalle : MonoBehaviour
{
    public bool bouleToucher;
    public bool bouletoucheSol;
    public bool bouleClone;
    public bool peutDupliquer;
    public Vector3 velociteNull;
    public GameObject grenadeGenerateur;
    //public GameObject boulle;
    //public bool boulABouger;

    // Start is called before the first frame update
    void Start()
    {
        bouleToucher = false; // si la boule est toucher par la main du joueur
        bouleClone = false; //si un clone à été faite 
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; //Assurez que laballe cloner rest immobile avant quelle soit toucher par le joeur
                                                                                           //transform.parent.namegrenadeGenerateur;
                                                                                           //Enlever pas nécéssaire
                                                                                           //boulABouger = false;
                                                                                           //bouletoucheSol = false;


        gameObject.transform.parent = grenadeGenerateur.transform;
        gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bouleToucher == true)
        {
            // Mettre l aboule en état libre et permettre de bouger 
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //transform.parent = null;
            Invoke("SpawnBalle", 0.5f);
            Invoke("EnleverParent", 0.4f);
        }

        if (bouleToucher == false)
        {
            // Mettre l aboule en état libre et permettre de bouger 
           // gameObject.GetComponent<Transform>().position = grenadeGenerateur.transform.position;
        }

    }
    private void OnTriggerEnter(Collider Collider)
    {
        if (Collider.gameObject.tag == "main")
        {
            bouleToucher = true;
        }
        




    }
    private void OnTriggerStay(Collider Collider)
    {
        if (Collider.gameObject.name == "GenerateurBalle")
        {
            peutDupliquer = false;
        }
    }
    private void OnTriggerExit(Collider Collider)
    {
        if (Collider.gameObject.name == "GenerateurBalle")
        {
            peutDupliquer = true;
        }
    }


    private void SpawnBalle()
    {

        // Vector3 positionSpawn = grenadeGenerateur.transformvector3

        if (bouleClone == false && peutDupliquer ==true)
        {
            Instantiate(gameObject, grenadeGenerateur.transform.position, grenadeGenerateur.transform.rotation); // Mettre la balle à la position initial


            Invoke("SuprimerBoule", 5f); //apres avoir été clonner suprimer l'objet.
            bouleClone = true;
        }


    }
    private void SuprimerBoule()
    {
        Destroy(gameObject);
    }
    private void EnleverParent() 
    {
        transform.parent = null;

    }
}
