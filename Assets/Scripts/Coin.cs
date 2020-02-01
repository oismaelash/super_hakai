using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour
{
    
	private Rigidbody2D rgdbd;
    private int value = 1;
	private bool flying = false;
	private AudioSource som;
	private Coroutine timer;
    
    
    // Start is called before the first frame update
    void Start()
	{
		rgdbd = GetComponent<Rigidbody2D> ();
		timer = StartCoroutine(Destroy(5f));
		som = GetComponentInChildren<AudioSource>();
		rgdbd.AddForce (Vector2.up * 4 + Vector2.right * Random.Range(-1, 1	), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
		if (flying)
			transform.position += Vector3.up * Time.deltaTime;
    }

    private void AddMoney()
    {
        if (PlayerPrefs.HasKey("coin"))
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + value);
        }
        else
        {
			PlayerPrefs.SetInt("coin", value);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddMoney();
			TextMeshPro text = GetComponentInChildren<TextMeshPro>();
			GetComponent<SpriteRenderer>().color = Color.clear;
			text.text = "+" + value;
			text.gameObject.SetActive(true);
			flying = true;
			timer = StartCoroutine(Destroy(0.5f));
			som.Play();
        }
    }

	IEnumerator Destroy(float time){
		yield return new WaitForSeconds(time);
		Destroy(this.gameObject);
	}
}