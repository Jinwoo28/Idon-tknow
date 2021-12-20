using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Population_Text : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RTS.Player.playerManager.instance.supply > RTS.Player.playerManager.instance.maxsupply)
        {
            if (RTS.Player.playerManager.instance.maxsupply < 200)
                this.GetComponent<Text>().text = RTS.Player.playerManager.instance.supply.ToString() + " / " + RTS.Player.playerManager.instance.maxsupply.ToString();
            else
            {
                this.GetComponent<Text>().text = RTS.Player.playerManager.instance.supply.ToString() + " / " + RTS.Player.playerManager.instance.limitsupply.ToString();
            }
            this.GetComponent<Text>().color = Color.red;
        }
        else
        {
            if (RTS.Player.playerManager.instance.maxsupply < 200)
                this.GetComponent<Text>().text = RTS.Player.playerManager.instance.supply.ToString() + " / " + RTS.Player.playerManager.instance.maxsupply.ToString();
            else
            {
                this.GetComponent<Text>().text = RTS.Player.playerManager.instance.supply.ToString() + " / " + RTS.Player.playerManager.instance.limitsupply.ToString();
            }


        }
    }
}
