using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowWave : MonoBehaviour
{
	TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
		text = GetComponentInChildren<TextMeshProUGUI> ();
    }

    // Update is called once per frame
    void Update()
    {
		text.text = "Wave: " + PlayerPrefs.GetInt("wave", 1);
    }
}