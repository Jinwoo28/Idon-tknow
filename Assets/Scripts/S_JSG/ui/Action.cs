using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UI.HUD
{
    public class Action : MonoBehaviour
    {
        public int slotnum;

        public int minerals;
        public void OnClick()
        {
             //ActionFrame.instance.StartSpawnTimer(name);
            InputManager.InputHandler.instance.UnitSpawn(name);
        }
        public void BuildClick()
        {


            RTS.Player.BuildManager.instance.SlotClick(slotnum, minerals);
        }
      

        
    }
}
