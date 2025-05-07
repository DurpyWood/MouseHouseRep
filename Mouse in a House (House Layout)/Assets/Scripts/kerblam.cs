using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kerblam : MonoBehaviour
{
    public string LevelName;

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(LevelName);
    }
}
