using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPMScript : MonoBehaviour
{
    public float valRPM;
    public GameObject subaru;

    void Start()
    {

    }
    void Update()
    {
        valRPM = subaru.GetComponent<AudioSource>().pitch;
        GetComponent<Text>().text = (valRPM * valRPM * 7000f).ToString("F0") + " rpm"; // Le moteur roule jusqu'à 7000RPM.
    }
}
