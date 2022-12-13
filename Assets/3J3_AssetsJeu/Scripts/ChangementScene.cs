using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using System.Linq;
public class ChangementScene : MonoBehaviour
{

    //InputVr
    [SerializeField]
    private XRNode xrNode = XRNode.LeftHand;
    private List<InputDevice> devices = new List<InputDevice>();
    private InputDevice device;
    //to avoid repeat readings
    public static bool primaryButtonIsPressed;
    public string nom;
    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xrNode, devices);
        device = devices.FirstOrDefault();    }
    private void OnEnable()
    {

        if (!device.isValid)
        {
            GetDevice();
        }

    }
    void Start()
    {
    }
    void Update()
    {
        if (!device.isValid)
        {
            GetDevice();
        }
        bool primaryButtonValue = false;
        InputFeatureUsage<bool> primaryButtonUsage = CommonUsages.primaryButton;

        if (Input.GetKeyDown("a"))
        {

            SceneManager.LoadScene("SceneJeu");
        }
        if (device.TryGetFeatureValue(primaryButtonUsage, out primaryButtonValue) && primaryButtonValue && !primaryButtonIsPressed)
        {
            primaryButtonIsPressed = true;
            SceneManager.LoadScene("SceneJeu");
        }
        else if (!primaryButtonValue && primaryButtonIsPressed)
        {
            primaryButtonIsPressed = false;

        }
    }
}
