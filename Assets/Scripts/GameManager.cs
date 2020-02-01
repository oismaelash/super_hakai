using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Building[] buildings;
	public Building lastClicked;
	private Vector3 position;
	static public GameManager instance;

	void Awake(){
		instance = this;
	}
		
    // Start is called before the first frame update
    void Start()
    {
		buildings = FindObjectsOfType<Building>();
		StartCoroutine(HakaiBuildingChoice());
	}

	public void spawnCoin(GameObject building)
	{
		for (int i = 0; i < 4; i++)
		{
			Vector2 buildingSize = building.GetComponent<SpriteRenderer>().bounds.size;
			position = new Vector3(Random.Range(-buildingSize.x/2, buildingSize.x/2), Random.Range(-buildingSize.y/2, buildingSize.y/2), -1) + building.transform.position;
			Instantiate(Resources.Load("Coin") as GameObject, position, Quaternion.identity);
		}
	}

	private IEnumerator HakaiBuildingChoice()
	{
		Debug.Log("Hakai");
		int buildingNumber = Random.Range( 0, buildings.Length);
		buildings[buildingNumber].hakai();
		yield return new WaitForSeconds(1);
		StartCoroutine(HakaiBuildingChoice());
    }
}