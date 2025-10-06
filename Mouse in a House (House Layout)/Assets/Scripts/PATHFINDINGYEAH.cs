using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PATHFINDINGYEAH : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject target;
    public GameObject Guy;
    public GameObject Mouse;
    public GameObject[] allNodes;
    public GameObject selectedNode;
    public float delay;
    public float timer;
    public float anger;
    public float chaseSpeed;
    public float normalSpeed;
    public FieldOfView script;
    public Vector3 memory;
    [SerializeField] AudioSource audioSource;
    public float startingPitch = 1f;

    void Awake()
    {
        allNodes = GameObject.FindGameObjectsWithTag("NodeTag");
        selectedNode = allNodes[Random.Range(0, allNodes.Length)];
        anger = 0.05f;
        delay = Random.Range(1, 5);
        normalSpeed = 4.5f;
        audioSource.pitch = startingPitch;
    }

    void FindNode()
    {
        selectedNode = allNodes[Random.Range(0, allNodes.Length)];
    }

    IEnumerator TIME()
    {
        transform.Rotate(0f, 3f * Time.deltaTime, 0f);
        yield return new WaitForSeconds(2);
    }

    void Update()
    {
        Vector3 a = new Vector3(Mouse.transform.position.x, Mouse.transform.position.y, Mouse.transform.position.z);
        Vector3 b = new Vector3(Guy.transform.position.x, Guy.transform.position.y, Guy.transform.position.z);
        float distance = Vector3.Distance(a, b);
        if (Guy.transform.position.x == selectedNode.transform.position.x && Guy.transform.position.z == selectedNode.transform.position.z)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                FindNode();
                timer = 0;
                delay = Random.Range(1, 3);
                navMeshAgent.speed += anger;
                normalSpeed = navMeshAgent.speed;
                chaseSpeed = navMeshAgent.speed * 1.5f;
            }
        }
        target = selectedNode;
        if (script.canSeePlayer == true)
        {
            target = Mouse;
            navMeshAgent.speed = chaseSpeed;
            memory = Mouse.transform.position;
            audioSource.pitch = startingPitch * 1.5f;
        }
        else
        {
            navMeshAgent.SetDestination(memory);
            StartCoroutine(TIME());
            navMeshAgent.speed = normalSpeed;
            audioSource.pitch = startingPitch;
        }
        if (target)
        {
            navMeshAgent.SetDestination(target.transform.position);
        }
        if (distance <= 1.75)
        {
            SceneManager.LoadScene("Hideout");
        }
    }
}
