using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class Building : MonoBehaviour
{
    #region VARIABLES

    public float maxLife = 100f;
	private float lifeCurrent = 100f;
	public float LifeCurrent
	{
		get { return lifeCurrent; }
		set
		{
			lifeCurrent = value;
			lifeSlider.value = lifeCurrent / maxLife;
			UpdateStatusViewBuilding();
		}
	}
	private int clicks = 0;
	private Vector2 position;
	[SerializeField] private AudioSource sound;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Slider lifeSlider;
	public Sprite[] states;

    #endregion

	private void UpdateStatusViewBuilding()
	{
		if (LifeCurrent < 1) 
		{
			spriteRenderer.sprite = states[4];
		} 
		else if (LifeCurrent < 30) 
		{
			spriteRenderer.sprite = states[3];
		} 
		else if (LifeCurrent < 60) 
		{
			spriteRenderer.sprite = states[2];
		} 
		else if (LifeCurrent < 99) 
		{
			spriteRenderer.sprite = states[1];
		} 
		else
		{
			spriteRenderer.sprite = states[0];
		}
	}

	/// <summary>
	/// The damage hit
	/// </summary>
    public void Hakai()
    {
		LifeCurrent -= GameManager.Instance.GetDamage();

        if (LifeCurrent <= 0f)
        {
			gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
		Debug.Log("OnMouseOver");
        if (Input.GetMouseButtonDown(0))
        {
			Debug.Log("GetMouseButtonDown");
			if (LifeCurrent < 100f)
            {
				LifeCurrent = Mathf.Min(LifeCurrent + GameManager.Instance.GetRepair(), maxLife);
				if (PlayerPrefs.GetInt ("Som", 1) == 1)
					sound.Play();
				if (clicks < 2 && (clicks == 0 || GameManager.Instance.lastClicked == this))
				{
					GameManager.Instance.lastClicked = this;
					clicks++;
				}	else if (GameManager.Instance.lastClicked != this)
				{
					clicks = 0;
				}	else
				{
					GameManager.Instance.spawnCoin(this.gameObject);
					clicks = 0;
				}
            }
        }
    }
}