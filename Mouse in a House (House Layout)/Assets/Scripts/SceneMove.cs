using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SceneMove : MonoBehaviour
{
    public bool inRange;
    public bool inRange2;
    public Transform playerCheck;
    public Transform playerCheck2;
    public float playerRadius = 1f;
    public LayerMask playerMask;
    public string LevelName;
    public TextMeshProUGUI interactUI; // interact [E]
    private bool wasON = false;
    private bool wasON2 = false;

    // Update is called once per frame
    void Update()
    {
        inRange = Physics.CheckSphere(playerCheck.position, playerRadius, playerMask);
        inRange2 = Physics.CheckSphere(playerCheck2.position, playerRadius, playerMask);
        if(inRange || inRange2)
        {
            interactUI.enabled = true;
            if(inRange)
            {
                wasON = true;
            }
            else{
                wasON2 = true;
            }
            
        }
        if(wasON && !inRange){
            interactUI.enabled = false;
            wasON = false;
        }
        else if(wasON2 && !inRange2){
            wasON2 = false;
            interactUI.enabled = false;
        }
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(LevelName);
        }
        if (inRange2 && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(LevelName);
        }
    }
}
