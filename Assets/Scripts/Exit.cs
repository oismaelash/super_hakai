using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Exit : MonoBehaviour
{
	public static bool exitAllowed = true;

	void Start ()
	{
		if(this.GetComponent<Button> ())
			this.GetComponent<Button> ().onClick.AddListener (() => exit ());
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			exit ();
	}

	public void exit ()
	{
		if (SceneManager.GetActiveScene ().buildIndex != 1 && exitAllowed)
			SceneManager.LoadScene (1);
		else
			Application.Quit ();
	}
}