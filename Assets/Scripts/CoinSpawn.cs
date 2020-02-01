using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{

    private Vector2 position;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2)) {
            Spawn();
        }
    }

    public void Spawn()
    {
        for (int i = 0; i < 3; i++)
        {
            position = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height)));
            Instantiate(Resources.Load("Coin") as GameObject, position, Quaternion.identity);
        }
    }


}
