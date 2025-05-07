using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public GameObject Guy;
    public GameObject[] allNodes;
    public GameObject[] visNodes;
    public GameObject selectedNode;
    public float speed;
    public Vector3 target;
    public float delay;
    public float timer;
    public float anger;

    

    void Awake()
    {
        allNodes = GameObject.FindGameObjectsWithTag("NodeTag");
        selectedNode = allNodes[Random.Range(0, allNodes.Length)];
        anger = 0.001f;
        delay = Random.Range(1, 5);
    }

    void FindNode()
    {
        selectedNode = allNodes[Random.Range(0, allNodes.Length)];
    }

    void Update()
    {
        anger = 0.001f;
        if (Guy.transform.position.x == selectedNode.transform.position.x && Guy.transform.position.z == selectedNode.transform.position.z)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                FindNode();
                timer = 0;
                if (delay > 1)
                {
                    delay = Random.Range(1, 5) - anger;
                }
                else
                {
                    delay = 1;
                }
                if (speed <= 0.1f)
                {
                    speed += anger;
                }
                else
                {
                    speed = 0.1f;
                }
            }
        }
        target = new Vector3(selectedNode.transform.position.x, Guy.transform.position.y, selectedNode.transform.position.z);
        Guy.transform.position = Vector3.MoveTowards(Guy.transform.position, target, speed);
        transform.LookAt(target);
    }
}