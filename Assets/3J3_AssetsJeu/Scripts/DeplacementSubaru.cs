using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeplacementSubaru : MonoBehaviour
{
    // D�claration des propri�t�s

    // Subaru
    Rigidbody rigidbodySubaru;
    public float vitesseAvance = 100f;
    public float vitesseAvanceMax = 1000f;
    public float vitesseReculeMax = -750f;
    public float vitesseTourne = 2500f;

    // Les roues
    public GameObject roueDevantGauche;
    public GameObject roueDevantDroite;
    public GameObject roueDerriereGauche;
    public GameObject roueDerriereDroite;

    // Les phares
    public GameObject phares;

    // Les sons
    AudioSource sonMoteurPiste;
    public AudioClip sonMoteur;
    public AudioClip sonCheckpoint;
    public AudioClip sonPenalite;

    // Autres objets
    public GameObject decompteur;
    public GameObject checkpoint;

    // Game Over
    public GameObject gameOver;
    GameObject refValCompteur;

    // R�ussite
    bool finJeu = false;
    public GameObject pointB;
    public GameObject reussi;

    // Gestionnaire de cam�ras
    public GameObject gestionnaireCameras;

    void Start()
    {
        rigidbodySubaru = GetComponent<Rigidbody>();
        sonMoteurPiste = GetComponent<AudioSource>();
        sonMoteurPiste.Play();
        gameOver.SetActive(false);
        reussi.SetActive(false);
    }

    void Update()
    {
        if (decompteur.GetComponent<DecompteurScript>().valCompteur == 0)
        {
            gameOver.SetActive(true);
            Invoke("ChangerSceneEchec", 3f);
        }
    }

    void FixedUpdate()
    {
        // Force physiques
        var forceTourne = Input.GetAxis("Horizontal") * vitesseTourne;
        rigidbodySubaru.AddRelativeTorque(0, forceTourne, 0);
        rigidbodySubaru.AddRelativeForce(0, 0, vitesseAvance*1.25f); // La voiture �tait un peu trop lente, donc sa vitesse est multipli�e par 1.25.

        // Animation des roues (utiliser les cam�ras 3 et 4 pour voir les animations)<
        // Probl�me: Les roues ne roulent pas � l'axe x lorsqu'elles tournent.
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            roueDevantGauche.GetComponent<Animator>().SetBool("tourneGauche", true);
            roueDevantDroite.GetComponent<Animator>().SetBool("tourneGauche", true);
            roueDevantGauche.GetComponent<Animator>().SetBool("tourneDroite", false);
            roueDevantDroite.GetComponent<Animator>().SetBool("tourneDroite", false);
        }
        else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            roueDevantGauche.GetComponent<Animator>().SetBool("tourneDroite", true);
            roueDevantDroite.GetComponent<Animator>().SetBool("tourneDroite", true);
            roueDevantGauche.GetComponent<Animator>().SetBool("tourneGauche", false);
            roueDevantDroite.GetComponent<Animator>().SetBool("tourneGauche", false);
        }
        else
        {
            roueDevantGauche.GetComponent<Animator>().SetBool("tourneGauche", false);
            roueDevantDroite.GetComponent<Animator>().SetBool("tourneGauche", false);
            roueDevantGauche.GetComponent<Animator>().SetBool("tourneDroite", false);
            roueDevantDroite.GetComponent<Animator>().SetBool("tourneDroite", false);
        }

        if (vitesseAvance > 250f)
        {
            roueDevantGauche.GetComponent<Animator>().SetBool("accelere", true);
            roueDevantDroite.GetComponent<Animator>().SetBool("accelere", true);
            roueDerriereGauche.GetComponent<Animator>().SetBool("accelere", true);
            roueDerriereDroite.GetComponent<Animator>().SetBool("accelere", true);
        }
        else if (vitesseAvance < -250f)
        {
            roueDevantGauche.GetComponent<Animator>().SetBool("decelere", true);
            roueDevantDroite.GetComponent<Animator>().SetBool("decelere", true);
            roueDerriereGauche.GetComponent<Animator>().SetBool("decelere", true);
            roueDerriereDroite.GetComponent<Animator>().SetBool("decelere", true);
        }
        else
        {
            roueDevantGauche.GetComponent<Animator>().SetBool("accelere", false);
            roueDevantDroite.GetComponent<Animator>().SetBool("accelere", false);
            roueDerriereGauche.GetComponent<Animator>().SetBool("accelere", false);
            roueDerriereDroite.GetComponent<Animator>().SetBool("accelere", false);
            roueDevantGauche.GetComponent<Animator>().SetBool("decelere", false);
            roueDevantDroite.GetComponent<Animator>().SetBool("decelere", false);
            roueDerriereGauche.GetComponent<Animator>().SetBool("decelere", false);
            roueDerriereDroite.GetComponent<Animator>().SetBool("decelere", false);
        }

        // Allumer et �teindre les phares
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (phares.activeSelf == true)
            {
                phares.SetActive(false);
            }
            else
            {
                phares.SetActive(true);
            }
        }

        // Augmenter la gravit� de la voiture
        rigidbodySubaru.AddForce(0, -200f, 0);

        // Acc�l�ration et d�c�l�ration involontaire de la voiture
        if (vitesseAvance > 2f)
        {
            vitesseAvance -= 2f;
        }
        else if (vitesseAvance < -2f)
        {
            vitesseAvance += 2f;
        }

        // Limiteurs de vitesse
        if (vitesseAvance > vitesseAvanceMax)
        {
            vitesseAvance = vitesseAvanceMax;
        }
        else if (vitesseAvance < vitesseReculeMax)
        {
            vitesseAvance = vitesseReculeMax;
        }

        // Une voiture ne peut pas se tourner lorsqu'elle est en arr�t
        if (vitesseAvance == 0f)
        {
            vitesseTourne = 0f;
        }
        else
        {
            vitesseTourne = 2500f;
        }

        // Acc�l�ration de la voiture
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            if (vitesseAvance < 500f)
            {
                vitesseAvance += 20f;
            }
            else
            {
                vitesseAvance += 2.5f;
            }
        }
        // D�c�l�ration de la voiture
        else if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            if (vitesseAvance > -500f && vitesseAvance < 0)
            {
                vitesseAvance -= 20f;
            }
            else
            {
                vitesseAvance -= 4f;
            }
        }

        // R�initialiser la voiture lorsqu'on est bloqu�
        if (Input.GetKeyDown("r"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z);
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        // P�nalit� de vitesse lorsque la voiture tourne
        if (forceTourne != 0f)
        {
            vitesseAvance -= 0.25f;
        }

        // Simulation du son de moteur
        if (vitesseAvance < 500f && vitesseAvance > -2f)
        {
            sonMoteurPiste.pitch = (vitesseAvance / 1000f) + 0.35f;
        }
        else if (vitesseAvance > 500f && vitesseAvance < 550f)
        {
            sonMoteurPiste.pitch = ((vitesseAvance / 550f)* 2f) - 1f;
        }
        else if (vitesseAvance > 550f && vitesseAvance < 625f)
        {
            sonMoteurPiste.pitch = ((vitesseAvance / 625f) * 2f) - 1f;
        }
        else if (vitesseAvance > 625f && vitesseAvance < 725f)
        {
            sonMoteurPiste.pitch = ((vitesseAvance / 725f) * 2f) - 1f;
        }
        else if (vitesseAvance > 725f && vitesseAvance < 850f)
        {
            sonMoteurPiste.pitch = ((vitesseAvance / 850f) * 2f) - 1f;
        }
        else if (vitesseAvance > 850f && vitesseAvance < 1000f)
        {
            sonMoteurPiste.pitch = ((vitesseAvance / 1000f) * 2f) - 1f;
        }
        else if (vitesseAvance < -500f && vitesseAvance > -750f) // Lorsqu'on recule
        {
            sonMoteurPiste.pitch = ((vitesseAvance / -750f) * 2f) - 1f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // P�nalit� de 1s pour toucher les pneus et les c�nes.
        if (collision.gameObject.tag == "Penalite")
        {
            decompteur.GetComponent<DecompteurScript>().valCompteur -= 1;
            sonMoteurPiste.PlayOneShot(sonPenalite);

            // D�truire l'objet de p�nalit� d�s qu'il est touch�.
            // Probl�me: M�me avec le boucle foreach, TOUS les objets de p�nalit�s sont enlev�s.
            /* GameObject[] objetsPenalites = GameObject.FindGameObjectsWithTag("Penalite");
            foreach(GameObject objetPenalite in objetsPenalites)
            {
                GameObject.Destroy(objetPenalite);
            } */
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Le checkpoint
        if (other.gameObject.tag == "Checkpoint")
        {
            decompteur.GetComponent<DecompteurScript>().valCompteur = 101;
            sonMoteurPiste.PlayOneShot(sonCheckpoint);
            Destroy(checkpoint); // D�truire le panneau invisible qui permet d'incr�menter le temps (afin de ne pas r�incr�menter en retournant).
        }
        // La destination
        else if (other.gameObject.tag == "PointB")
        {
            finJeu = true;
            sonMoteurPiste.PlayOneShot(sonCheckpoint);
            Destroy(pointB);
            reussi.SetActive(true);
            Invoke("ChangerSceneReussi", 3f);
        }
    }

    void ChangerSceneEchec()
    {
        SceneManager.LoadScene("SceneGameOver");
    }

    void ChangerSceneReussi()
    {
        SceneManager.LoadScene("SceneReussi");
    }
}
