using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
	public Toggle tSound;

	void Start ()
	{
		if(this.GetComponent<Toggle> ())
			tSound = this.GetComponent<Toggle> ();
		tSound.isOn = PlayerPrefs.GetInt ("Som", 1) == 1;
	}

	public void toggleSound ()
	{
		PlayerPrefs.SetInt ("Som", tSound.isOn ? 1 : 0);
	}
}
