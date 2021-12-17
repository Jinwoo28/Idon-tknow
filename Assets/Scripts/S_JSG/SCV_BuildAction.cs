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
            ActionFrame.instance.SetActionButtons(actions); //버튼 활성화

        }

        
    }
}
