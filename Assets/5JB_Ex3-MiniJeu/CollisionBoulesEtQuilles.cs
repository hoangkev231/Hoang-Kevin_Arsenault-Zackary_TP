using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionBoulesEtQuilles : MonoBehaviour
{
    public GameObject compteurEnnemi;
    public GameObject Ennemi;
    public int valCompteurEnnemi;
    public AudioClip sonPointage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boule")
        {
            valCompteurEnnemi++;
            compteurEnnemi.GetComponent<Text>().text = valCompteurEnnemi.ToString() + " / 10";
            Ennemi.GetComponent<BoxCollider>().enabled = false;
            Ennemi.GetComponent<AudioSource>().PlayOneShot(sonPointage);
        }
    }
}
