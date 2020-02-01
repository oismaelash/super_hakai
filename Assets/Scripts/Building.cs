using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Building : MonoBehaviour
{
    
    private float life = 100f;
    private int clicks = 0;
    private Vector2 position;
    // Start is called before the first frame update
    void Start()
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
            if (clicks < 2)
            {
                clicks++;
            }
            else
            {
				CoinSpawn.instance.Spawn(this.gameObject);
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