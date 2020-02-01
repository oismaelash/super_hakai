using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsControl : MonoBehaviour
{
    public bool _canClicker = false;
    public bool _canShield = false;
    public bool _canFreeze = false;
    public bool _canMakeTheKO = false;
    public bool _canDontGiveUp = false;
    public bool _canZordTime = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickerPowerupOn() {
        _canClicker = true;
        
        for (int i = 0; i < GameManager.instance.buildings.Length; i++)
                GameManager.instance.buildings[i].repair = GameManager.instance.buildings[i].repair * 1.5f;
        

    }

    public void ShieldPowerupOn() {
        _canShield = true;
        
        for (int i = 0; i < GameManager.instance.buildings.Length; i++)
                GameManager.instance.buildings[i].damage = 5f;
        
    }

    

    public void FreezePowerupOn() {
        _canFreeze = true;



    }

    public void MakeTheKOPowerupOn() { }

    public void DontGiveUpPowerupOn() { }

    public void ZordTimePowerupOn() { }
}
