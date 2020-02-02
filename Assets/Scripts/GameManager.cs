using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Building[] buildings;
	public Building lastClicked;
	private Vector3 position;
	static public GameManager instance;
	private Coroutine timer;
	public Transform kaiju;
	public Transform robot;
	private Vector3 kaijuPos;
	private Vector3 robotPos;
	private float count = 0;
    private bool animate = true;

    public bool _canClicker = false;
    public bool _canShield = false;
    public bool _canFreeze = false;
    public bool _canMakeTheKO = false;
    public bool _canDontGiveUp = false;
    public bool _canZordTime = false;

    void Awake(){
		instance = this;
	}
		
    // Start is called before the first frame update
    void Start()
    {
		buildings = FindObjectsOfType<Building>();
		timer = StartCoroutine(HakaiBuildingChoice());
		kaijuPos = kaiju.position;
		robotPos = robot.position;
	}

	void Update(){
        if (animate)
        {
            count += Time.deltaTime * 8;
            if (count > Mathf.PI * 2) count -= Mathf.PI * 2;
            kaiju.position = kaijuPos +
                Vector3.right * -Mathf.Cos(count) / 2 +
                Vector3.up * Mathf.Abs(Mathf.Sin(count)) / 2;
            robot.position = robotPos +
                Vector3.right * Mathf.Cos(count) / 2 +
                Vector3.up * Mathf.Abs(Mathf.Sin(count)) / 2;
        }
		
	}

	public void spawnCoin(GameObject building)
	{
		for (int i = 0; i < 4; i++)
		{
			Vector2 buildingSize = building.GetComponent<SpriteRenderer>().bounds.size;
			position = new Vector3(Random.Range(-buildingSize.x/2, buildingSize.x/2), Random.Range(-buildingSize.y/2, buildingSize.y/2), -1) + building.transform.position;
			Instantiate(Resources.Load("Coin") as GameObject, position, Quaternion.identity);
		}
	}

	private IEnumerator HakaiBuildingChoice()
	{
		int buildingNumber = Random.Range( 0, buildings.Length);
		buildings[buildingNumber].hakai();
		yield return new WaitForSeconds(1);
		timer = StartCoroutine(HakaiBuildingChoice());
    }

    public void ClickerPowerupOn()
    {


        for (int i = 0; i < GameManager.instance.buildings.Length; i++)
            GameManager.instance.buildings[i].repair = GameManager.instance.buildings[i].repair * 1.5f;


    }

    public void ShieldPowerupOn()
    {


        for (int i = 0; i < GameManager.instance.buildings.Length; i++)
            GameManager.instance.buildings[i].damage = 5f;

    }



    public void FreezePowerupOn()
    {
        _canFreeze = false;
        animate = false;
        this.StopAllCoroutines();
        StartCoroutine(FreezePowerDownRoutime());
    }

    public IEnumerator FreezePowerDownRoutime()
    {
        
        yield return new WaitForSeconds(4f);
        timer = StartCoroutine(HakaiBuildingChoice());
        animate = true;
    }

    public void MakeTheKOPowerupOn()
    {

    }

    public void DontGiveUpPowerupOn()
    {

    }

    public void ZordTimePowerupOn()
    {

    }
}