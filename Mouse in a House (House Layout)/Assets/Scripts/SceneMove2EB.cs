using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove2EB : MonoBehaviour
{
    public bool inRange; //if you are in range to interact with the tunnle
    public bool winning;
    public Transform playerCheck;
    public float playerRadius = 0.55f;
    public LayerMask playerMask;
    public string LevelName; // Name of level you want to travle to
    public FoodDetection foodDetect; //Food detection script
    public List<string> foodList = new List<string>(10); //what food you have stored
    public int points = 0; //amount of points given
    public int temppoints = 0; //amount of points given
    public TMPro.TextMeshProUGUI displayText;
    public TMPro.TextMeshProUGUI HDT;

    // Update is called once per frame
    void Update()
    {
        inRange = Physics.CheckSphere(playerCheck.position, playerRadius, playerMask);
        if(inRange && Input.GetKeyDown(KeyCode.E) && foodDetect.PickedUp != false) //if you hold a food
        {
            foodList.Add(foodDetect.currentObject.name); // Adds the food to the list
            if (foodDetect.currentObject.name == "Cookie")
            {
                temppoints += 500;
                winning = true;
                displayText.text = temppoints.ToString();
            }
            else if (foodDetect.currentObject.name == "orange" || foodDetect.currentObject.name == "grape")
            {
                temppoints += 300;
                displayText.text = temppoints.ToString();
            }
            else if (foodDetect.currentObject.name == "banana")
            {
                temppoints += 150;
                displayText.text = temppoints.ToString();
            }
            else if (foodDetect.currentObject.name == "BreadCrumb")
            {
                temppoints += 50;
                displayText.text = temppoints.ToString();
            }
            Debug.Log(string.Join(", ", foodList));
            Destroy(foodDetect.currentObject); // deletes the food
            foodDetect.currentObject = null;// makes it so that you lose the info over the food
            foodDetect.PickedUp = false;// you are not holding a food anymore
        }

        //If you are not holding a Food
        else if ( inRange && Input.GetKeyDown(KeyCode.E) && foodDetect.PickedUp != true && foodDetect.currentObject == null)
        {
            if(foodList.Count == 0 && winning==true) //If you have no food
            {
                SceneManager.LoadScene(LevelName);
            }
            else if(foodList.Count > 0 && winning == true) // If you have food
            {
                SceneManager.LoadScene(LevelName);
                displayText = HDT;
                foreach(string i in foodList)
                {
                    if(i == "Cookie")
                    {
                        points += 500;
                    }
                    else if(i == "orange" || i == "grape")
                    {
                        points += 300;
                    }
                    else if(i == "banana")
                    {
                        points += 150;
                    }
                    else if(i == "BreadCrumb")
                    {
                        points += 50;
                    }
                    displayText.text = points.ToString();
                }
                foodList.Clear(); // emptys the list 
            }   
        }
    }
}
