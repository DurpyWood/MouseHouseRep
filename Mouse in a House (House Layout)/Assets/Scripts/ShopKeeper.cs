using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    public bool inRange; //if you are in range to interact with the shop
    public Transform playerCheck; //the player
    public float playerRadius = 0.55f; //how big the collition of the player is
    public LayerMask playerMask; //what layer it looks for
    public GameObject point; //center of the detection
    public GameObject nextcamera;// shopkeepers cam
    public GameObject playerCam; // the players cam
    public GameObject player; // the player
    public GameObject playerref; // the point where the player will be put during dialog
    public Transform shopkeeper; // the shopkeepers cords
    public  TextMeshProUGUI dialogeText1; //what he will say
    public TextMeshProUGUI dialogeText2; //the next line I want him to say
    public TextMeshProUGUI interactText; // interact [E]
    public RawImage backround; // the paper backround for the text
    private int HowMuchSaid = 0; //tracks which dialoge we are on
    private int waitTime = 0; // makes I so you don't click once and do the intier coversation
    
    void Update()
    {
        inRange = Physics.CheckSphere(playerCheck.position, playerRadius, playerMask);
        if(inRange)
        {
            waitTime++;
            interactText.enabled = true;
        }
        if(!inRange && waitTime > 0)
        {
            interactText.enabled = false;
            waitTime = 0;
        }
        if (inRange && Input.GetKeyDown(KeyCode.E) && HowMuchSaid == 0) // if you are in range of the shop keeper
        {
            playerCam.GetComponent<Camera>().enabled = false; //Turns off the camera connected to the player
            nextcamera.GetComponent<Camera>().enabled = true; // Turns on the shopkeeper camera
            player.transform.position = new Vector3(playerref.transform.position.x, playerref.transform.position.y, playerref.transform.position.z); //puts the player in front of the shopkeeper
            player.GetComponent<PlayerMovement>().enabled = false; //turns off the players movement
            player.transform.LookAt(shopkeeper); // makes the player look at the shopkeeper
            Cursor.lockState = CursorLockMode.None; //unlocks the mouse
            Cursor.visible = true; //makes the mouse visable
            HowMuchSaid++;
        }    
        if(HowMuchSaid == 1 && Input.GetKeyDown(KeyCode.E)){
            dialogeText1.enabled = true;
            backround.enabled = true;
            HowMuchSaid++;
            waitTime = 0;
        }
        else if(Input.GetKeyDown(KeyCode.E) && HowMuchSaid == 2 && waitTime > 5)
        {
            dialogeText1.enabled = false; //disables the first text box
            dialogeText2.enabled = true; //shows what is said next
            HowMuchSaid++;
            waitTime = 0;
        }
        if(Input.GetKeyDown(KeyCode.E) && HowMuchSaid == 3 && waitTime > 5)
        {
            backround.enabled = false; //disables the text box
            dialogeText2.enabled = false; //disables the second text
            HowMuchSaid++;
            waitTime = 0;
        }
        if(Input.GetKeyDown(KeyCode.E) && HowMuchSaid == 4 && waitTime > 5)
        {
            nextcamera.GetComponent<Camera>().enabled = false; // Turns on the shopkeeper camera
            playerCam.GetComponent<Camera>().enabled = true; //Turns off the camera connected to the player
            player.GetComponent<PlayerMovement>().enabled = true; //turns off the players movement
            Cursor.lockState = CursorLockMode.Locked; //unlocks the mouse
            Cursor.visible = false; //makes the mouse visable
            HowMuchSaid = 0;
        }

    }
}
