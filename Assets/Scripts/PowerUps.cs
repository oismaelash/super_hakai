using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField]
    private int powerupID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PowerUpsControl puc = GameObject.Find("Camera").GetComponent<PowerUpsControl>();

            if (powerupID == 0)
            {
                puc.FreezePowerupOn();
            }
            else if (powerupID == 1)
            {
                puc.MakeTheKOPowerupOn();
            }
            else if (powerupID == 2)
            {
                puc.ZordTimePowerupOn();
            }
        }
    }
}
