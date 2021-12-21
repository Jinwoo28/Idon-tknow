using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UI.HUD
{
    public class SCV_BuildAction : MonoBehaviour
    {
        public PlayerAction actions;

        

       

        public void scvBuild()
        {

            ActionFrame.instance.ClearActions();
            if (actions.BTNLIST_NUM == 1)
            {
            RTS.Player.BuildManager.instance.B_buildingcheck = true;

            }
            else if (actions.BTNLIST_NUM == 2)
            {
                RTS.Player.BuildManager.instance.A_buildingcheck =  true;
            }
            ActionFrame.instance.SetActionButtons(actions); //버튼 활성화

        }

        
    }
}
