using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    
    private float life = 100f;
    private int clicks = 0;
    private Vector2 position;
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hakai()
    {
        
        life -= 8f;
        if (life <= 0f)
        {
            Destroy(this.gameObject);
        }
        Debug.Log(this.gameObject.name + " " + life);  
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CoinSpawn coinSpawn = GameObject.Find("Main Camera").GetComponent<CoinSpawn>();
            if (clicks < 2)
            {
                clicks++;
            }
            else
            {
                coinSpawn.Spawn();
                clicks = 0;
            }

            if (life < 100f)
            {
                life += 12.5f;
                if (life >= 100f)
                {
                    life = 100f;
                }
            }
        }
    }
}
