using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    

    private int value = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void AddMoney()
    {
        if (PlayerPrefs.HasKey("coin"))
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + value);
        }
        else
        {
            PlayerPrefs.SetInt("coin", 1);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddMoney();
            Debug.Log(PlayerPrefs.GetInt("coin"));
            Destroy(this.gameObject);
        }
    }
}
