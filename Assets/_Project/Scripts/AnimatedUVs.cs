using UnityEngine;
using System.Collections;

public class AnimatedUVs : MonoBehaviour {
	public int materialIndex = 0;
	public Vector2 uvAnimationRate = new Vector2(0.01f, 0f);
	public string textureName = "_MainTex";


	Vector2 uvOffset = Vector2.zero;
	void LateUpdate() {
		uvOffset += (uvAnimationRate * Time.deltaTime);
		GetComponent<Renderer> ().materials [materialIndex].SetTextureOffset (textureName, uvOffset);
	}
}