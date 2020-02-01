using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Building : MonoBehaviour
{

	private float maxLife = 100f;
	private float life = 100f;
    private int clicks = 0;
	private Vector2 position;
	private const float repair = 12.5f; 
	private const float damage = 8f;
	private SpriteRenderer sp;
	private Slider bar;
	public Sprite[] states;


	// Start is called before the first frame update
	void Start()
	{
		bar = GetComponentInChildren<Slider>();
		sp  = GetComponentInChildren<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		bar.value = life/maxLife;
		if(life < 30){
			sp.sprite = states[2];
		}else if (life < 60){
			sp.sprite = states[1];
		}else{
			sp.sprite = states[0];
		}
	}

    public void Hakai()
    {
        
		life -= damage;
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

            if (life < 100f)
            {
				life = Mathf.Min(life + repair, maxLife);
				if (clicks < 2)
				{
					clicks++;
				}
				else
				{
					CoinSpawn.instance.Spawn(this.gameObject);
					clicks = 0;
				}
            }
        }
    }
}