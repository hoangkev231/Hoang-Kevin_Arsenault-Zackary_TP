using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionBoulesEtQuilles : MonoBehaviour
{
    public GameObject compteurQuilles;
    public GameObject Quille;
    public int valCompteurQuilles;
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
            valCompteurQuilles++;
            compteurQuilles.GetComponent<Text>().text = valCompteurQuilles.ToString() + " / 10";
            Quille.GetComponent<CapsuleCollider>().enabled = false;
            Quille.GetComponent<AudioSource>().PlayOneShot(sonPointage);
        }
    }
}
