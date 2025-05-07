using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FoodDetection : MonoBehaviour
{
    public GameObject Player;
    public LayerMask interactableLayer; // Assign the layer in the Inspector
    public GameObject currentObject;
    public Rigidbody rig;
    public bool PickedUp = false;
    public AudioSource audiosource;
    public TextMeshProUGUI interactText; // interact [E]

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object is on the interactable layer
        if (((1 << other.gameObject.layer) & interactableLayer) != 0 & PickedUp != true)
        {
            currentObject = other.gameObject;  
            interactText.enabled = true;  
        }
    }
    void OnTriggerExit(Collider other)
    {
        // Clear the reference when the object exits the trigger
        if (currentObject == other.gameObject & PickedUp != true)
        {
            currentObject = null;
            interactText.enabled = false;
        }
    }

    void Update()
    {
        if (currentObject != null && Input.GetKeyUp(KeyCode.E) & PickedUp != true) // Pick up
        {
            //audiosource.Play();
            PickedUp = true;
            interactText.enabled = false;
            rig = currentObject.GetComponent<Rigidbody>();
            currentObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1, Player.transform.position.z);
            currentObject.transform.SetParent(Player.transform);
            rig.velocity = new Vector3(0, 0, 0);
            currentObject.GetComponent<Rigidbody>(). useGravity = false;
            rig.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
        }
        else if(currentObject != null && Input.GetKeyUp(KeyCode.E) & PickedUp == true) //Throw
        {
            currentObject.GetComponent<Rigidbody>().useGravity = true;
            rig.constraints = RigidbodyConstraints.None;
            currentObject.transform.parent = null;
            rig.AddForce(transform.up * 200f);
            rig.AddForce(transform.forward * 250f);
            PickedUp = false;
            currentObject = null;

        }
    }
}
