using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyDepot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RTS.Player.playerManager.instance.maxsupply += 10;
        supplycheck();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void supplycheck()
    {
        if (RTS.Player.playerManager.instance.maxsupply > 200)
        {
            RTS.Player.playerManager.instance.maxsupply = 200;
        }


    }
}
