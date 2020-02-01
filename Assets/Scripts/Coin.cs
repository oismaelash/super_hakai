using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Coin : MonoBehaviour
{
    

    private int value = 1;
	private bool flying = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(Destroy(1.5f));
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
			StartCoroutine(Destroy(0.5f));
        }
    }

	IEnumerator Destroy(float time){
		yield return new WaitForSeconds(time);
		Destroy(this.gameObject);
	}
}