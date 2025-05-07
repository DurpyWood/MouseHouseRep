using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FoodSpawn : MonoBehaviour
{
    public List<GameObject> FoodList;
    public GameObject[] Locations;
    public GameObject current;
    public GameObject currentSpot;
    public int ind;

    void Start()
    {
        FoodList = new List<GameObject>();
        FoodList.AddRange(GameObject.FindGameObjectsWithTag("FoodTag"));
        Locations = GameObject.FindGameObjectsWithTag("SpotTag");
        FoodList = FoodList.OrderBy(x => Random.value).ToList();
        ind = 0;
    }

    void Update()
    {
        if (ind < 6)
        {
            foreach (GameObject FoodTag in FoodList)
            {
                current = FoodList[ind];
                currentSpot = Locations[ind];
                current.transform.position = currentSpot.transform.position;
                ind++;
            }
        }
    }
}
