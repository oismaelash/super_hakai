using UnityEngine;

public class PowerUpsShop : MonoBehaviour
{
    private static readonly int[] costPowerUp = { 15, 18, 20, 30, 20, 28 };

    public static void Buy(int powerupID)
    {
        if (costPowerUp[powerupID] >= PlayerPrefs.GetInt(Constants.COIN_NAME_PLAYERPREFS))
        {
            if (powerupID == 0)
            {
                GameManager.Instance._canClicker = true;
            }
            else if (powerupID == 1)
            {
                GameManager.Instance._canShield = true;
            }
            else if (powerupID == 2)
            {
                GameManager.Instance._canFreeze = true;
            }
            else if (powerupID == 3)
            {
                GameManager.Instance._canMakeTheKO = true;
            }
            else if (powerupID == 4)
            {
                GameManager.Instance._canDontGiveUp = true;
            }
            else if (powerupID == 5)
            {
                GameManager.Instance._canZordTime = true;
            }

            int newValueCoins = PlayerPrefs.GetInt(Constants.COIN_NAME_PLAYERPREFS) - costPowerUp[powerupID];
            PlayerPrefs.SetInt(Constants.COIN_NAME_PLAYERPREFS, newValueCoins);
        }
    } 
}