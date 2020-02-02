using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
	void Start ()
	{
		if(this.GetComponent<Button> ())
			this.GetComponent<Button> ().onClick.AddListener (() => exit ());
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			SceneManager.LoadScene (0);
	}

	public void exit ()
	{
		if (SceneManager.GetActiveScene ().buildIndex != 0)
			SceneManager.LoadScene (0);
		else
			Application.Quit ();
	}
}