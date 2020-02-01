using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{

    private Vector3 position;
	static public CoinSpawn instance;

	void Awake(){
		instance = this;
	}

    public void Spawn(GameObject building)
    {
        for (int i = 0; i < 4; i++)
        {
			Vector2 buildingSize = building.GetComponent<SpriteRenderer>().bounds.size;
			position = new Vector3(Random.Range(-buildingSize.x/2, buildingSize.x/2), Random.Range(-buildingSize.y/2, buildingSize.y/2), -1) + building.transform.position;
            Instantiate(Resources.Load("Coin") as GameObject, position, Quaternion.identity);
        }
    }


}