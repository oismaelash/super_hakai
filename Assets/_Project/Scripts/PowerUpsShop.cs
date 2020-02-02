using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsShop : MonoBehaviour
{
   
    static private int[] cost = { 15, 18, 20, 30, 20, 28 };


    static public void buy(int powerupID)
    {
        if (PlayerPrefs.GetInt("coin") > cost[powerupID])
        {

        }
        else  {
            PowerUpsControl puc = GameObject.Find("Camera").GetComponent<PowerUpsControl>();
            if (powerupID == 0)
            {
                GameManager.instance._canClicker = true;
            }
            else if (powerupID == 1)
            {
                GameManager.instance._canShield = true;
            }
            else if (powerupID == 2)
            {
                GameManager.instance._canFreeze = true;
            }
            else if (powerupID == 3)
            {
                GameManager.instance._canMakeTheKO = true;
            }
            else if (powerupID == 4)
            {
                GameManager.instance._canDontGiveUp = true;
            }
            else if (powerupID == 5)
            {
                GameManager.instance._canZordTime = true;
            }

            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - cost[powerupID]);
        }
        
    } 
}
