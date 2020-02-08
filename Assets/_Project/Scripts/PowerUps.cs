using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public void activate(int powerupID)
    {
        if (powerupID == 0)
        {
            GameManager.Instance.FreezePowerupOn();
        }
        else if (powerupID == 1)
        {
            GameManager.Instance.MakeTheKOPowerupOn();
        }
        else if (powerupID == 2)
        {
            GameManager.Instance.DontGiveUpPowerupOn();
        }
        else if (powerupID == 3)
        {
            GameManager.Instance.ZordTimePowerupOn();
        }
    }
}
