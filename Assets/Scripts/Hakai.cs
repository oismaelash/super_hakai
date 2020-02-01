using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hakai : MonoBehaviour
{
	private Building[] buildings;
	static public Hakai instance;

	void Awake(){
		instance = this;
	}


    // Start is called before the first frame update
    void Start()
    {
		buildings = FindObjectsOfType<Building>();
		StartCoroutine(HakaiBuildingChoice());
    }

	private IEnumerator HakaiBuildingChoice()
	{
		Debug.Log("Hakai");
		int buildingNumber = Random.Range( 0, buildings.Length);
		buildings[buildingNumber].Hakai();
		yield return new WaitForSeconds(1);
		StartCoroutine(HakaiBuildingChoice());
    }
}