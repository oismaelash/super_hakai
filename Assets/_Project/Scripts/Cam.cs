using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {
	public Color color1 = new Color(0.168f,0.568f,0.945f,1);
	public Color color2 = new Color(0.945f,0.568f,0.168f,1);
	public static int time;
	private float t;

	void Start() {
		GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
	}

	void Update() {
		time = System.DateTime.Now.Millisecond + System.DateTime.Now.Second * 1000 + System.DateTime.Now.Minute * 60000 + System.DateTime.Now.Hour * 3600000;
		t = (float)time / 43200000f;
		if (t < 1)
			GetComponent<Camera>().backgroundColor = Color.Lerp(color1, color2, t);
		else
			GetComponent<Camera>().backgroundColor = Color.Lerp(color2, color1, t-1f);	
		if (Input.GetKeyDown ("escape"))
			Application.Quit ();

	}
}