using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsShop : MonoBehaviour
{
    [SerializeField]
    private int powerupID;
    private int[] cost = { 15, 18, 20, 30, 20, 28 };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void buy()
    {
        if (PlayerPrefs.GetInt("coin") > cost[powerupID])
        {

        }
        else  {
            PowerUpsControl puc = GameObject.Find("Camera").GetComponent<PowerUpsControl>();
            if (powerupID == 0)
            {

                puc._canClicker = true;
            }
            else if (powerupID == 1)
            {
                puc._canShield = true;
            }
            else if (powerupID == 2)
            {
                puc._canFreeze = true;
            }
            else if (powerupID == 3)
            {
                puc._canMakeTheKO = true;
            }
            else if (powerupID == 4)
            {
                puc._canDontGiveUp = true;
            }
            else if (powerupID == 5)
            {
                puc._canZordTime = true;
            }

            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - cost[powerupID]);
        }
        
    } 
}
