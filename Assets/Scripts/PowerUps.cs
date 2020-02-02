using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public void activate(int powerupID)
    {
        if (powerupID == 0)
        {
            GameManager.instance.FreezePowerupOn();
        }
        else if (powerupID == 1)
        {
            GameManager.instance.MakeTheKOPowerupOn();
        }
        else if (powerupID == 2)
        {
            GameManager.instance.DontGiveUpPowerupOn();
        }
        else if (powerupID == 3)
        {
            GameManager.instance.ZordTimePowerupOn();
        }
    }
}
