using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public bool inRange;
    public bool inRange2;
    public Transform playerCheck;
    public Transform playerCheck2;
    public float playerRadius = 1f;
    public LayerMask playerMask;
    public string LevelName;

    // Update is called once per frame
    void Update()
    {
        inRange = Physics.CheckSphere(playerCheck.position, playerRadius, playerMask);
        inRange2 = Physics.CheckSphere(playerCheck2.position, playerRadius, playerMask);
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
