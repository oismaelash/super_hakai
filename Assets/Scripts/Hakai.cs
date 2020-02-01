using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hakai : MonoBehaviour
{
    private string buildingNumber;
    private float timer = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            HakaiBuildingChoice();
            timer = 1f;
        }
    }



    private void HakaiBuildingChoice()
    {
        buildingNumber = Random.Range( 1, 4).ToString();
        
        if (GameObject.Find("Building" + buildingNumber) == null)
        {
            HakaiBuildingChoice();
        }
        else
        {
            Building building = GameObject.Find("Building" + buildingNumber).GetComponent<Building>();
            building.Hakai();
        }
        
    }
}
