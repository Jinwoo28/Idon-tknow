using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCenter : MonoBehaviour
{
  
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
