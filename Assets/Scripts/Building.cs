using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Building : MonoBehaviour
{
	private int maxHealth = 1000;
	private int health 	  = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Shatter(int damage){
		if (health >= 0){
			health = Mathf.Max(0, health - damage);
		}
	}

	void OnMouseDown(){
		if (health <= maxHealth){
			health = Mathf.Min(health - 1, maxHealth);
		}
	}
}